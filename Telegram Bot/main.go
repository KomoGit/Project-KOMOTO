package main

import (
	"encoding/json"
	"fmt"
	"log"
	"net/http"
	"os"
	"strings"
	"sync"
	"time"

	tgbotapi "github.com/go-telegram-bot-api/telegram-bot-api/v5"
)

var links = SplitData(apiLink)
var ids = SplitData(chatId)

func main() {
	ch := make(chan string, 2)
	var wg sync.WaitGroup

	for i := 0; i < len(links); i++ {
		conf := BotConfig{
			api_link: links[i],
			chat_id:  ConvertChatId(ids[i]),
		}

		// Increment the WaitGroup counter before starting a goroutine.
		wg.Add(1)
		go func(conf BotConfig) {
			defer wg.Done()
			BotController(ch, conf)
		}(conf)
	}

	// Wait for all goroutines to finish.
	wg.Wait()

	// Close the channel after all goroutines are done.
	close(ch)

	// Receive and print messages from the channel.
	for msg := range ch {
		fmt.Println(msg)
	}
}

func BotController(c chan string, conf BotConfig) {
	i := 0
	for _, item := range GetJobs(conf.api_link) {
		if i == 4 {
			time.Sleep(SLEEP_DURATION)
			i = 0
		}
		Bot(conf.chat_id, item)
		i++
	}
	c <- "Bot is done."
}

func Bot(chatId int64, job Job) {
	bot, err := tgbotapi.NewBotAPI(os.Getenv("BOT_TOKEN"))
	if err != nil {
		log.Panic(err)
	}

	bot.Debug = getEnvBool()
	u := tgbotapi.NewUpdate(0)
	u.Timeout = 60

	msg := tgbotapi.NewMessage(chatId, SendJob(job))
	msg.ReplyMarkup = tgbotapi.NewInlineKeyboardMarkup(
		tgbotapi.NewInlineKeyboardRow(
			tgbotapi.NewInlineKeyboardButtonURL("Auto Apply \U00002705", job.Link),
			tgbotapi.NewInlineKeyboardButtonURL("Save \U0001F4BE", "www.example.com"))) // Save link will probably be a constant

	if _, err = bot.Send(msg); err != nil {
		panic(err)
	}
}

// Send Data
func SendJob(job Job) string {
	return fmt.Sprintf("Title: %s\nDescription: %s\nCompany: %s\nCategory: %s\nExpiration Date: %s", job.Title, job.Description, job.Employer.Name, job.Cat.Name, strings.Split(job.ExpDate, "T")[0])
}

// Retireve Data
func GetJobs(link string) []Job {
	var allItems []Job
	req, err := http.NewRequest("GET", link, nil) //Link should be converted
	if err != nil {
		log.Fatal(err)
	}
	// Add the x-api-key header
	req.Header.Set("x-api-key", apiKey)
	resp, err := http.DefaultClient.Do(req)
	if err != nil {
		panic(err)
	}
	defer resp.Body.Close()
	// URL of the API endpoint
	for {
		var items []Job
		if err := json.NewDecoder(resp.Body).Decode(&items); err != nil {
			log.Fatal(err)
		}
		// Append items to the slice
		allItems = append(allItems, items...)
		// Check if there are more items to fetch
		if len(items) == len(allItems) {
			break // No more items to fetch
		}
	}
	return allItems
}
