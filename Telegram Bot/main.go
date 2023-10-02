package main

import (
	"encoding/json"
	"fmt"
	"log"
	"net/http"
	"os"
	"strconv"
	"time"

	tgbotapi "github.com/go-telegram-bot-api/telegram-bot-api/v5"
)

var (
	chatId  int64  = GetChatId(os.Getenv("CHAT_ID")) //Converts to int64
	apiLink string = os.Getenv("API_LINK")
	apiKey  string = os.Getenv("API_KEY")
)

const SLEEP_DURATION = time.Second * time.Duration(5) //5 Seconds

type Category struct {
	Name string `json:"name"`
	ID   int    `json:"id"`
}

type Job struct {
	Title       string   `json:"title"`
	Description string   `json:"description"`
	Link        string   `json:"link"`
	CategoryID  int      `json:"categoryId"`
	ID          int      `json:"id"`
	Cat         Category `json:"jobCategory"`
}

func main() {
	for _, item := range GetJobs() {
		BotController(item)
		time.Sleep(SLEEP_DURATION)
	}
}

func BotController(job Job) {
	bot, err := tgbotapi.NewBotAPI(os.Getenv("BOT_TOKEN"))
	if err != nil {
		log.Panic(err)
	}

	bot.Debug = true
	log.Printf("Authorized on account %s", bot.Self.UserName)
	u := tgbotapi.NewUpdate(0)
	u.Timeout = 60

	msg := tgbotapi.NewMessage(chatId, SendJob(job))
	msg.ReplyMarkup = SendKeyboard(job)
	// Send the message.
	if _, err = bot.Send(msg); err != nil {
		panic(err)
	}
}

func GetChatId(str string) int64 {
	if n, err := strconv.ParseInt(str, 10, 64); err == nil {
		return n
	}
	return 0
}

func SendJob(job Job) string {
	return fmt.Sprintf("%s \n%s\n%s", job.Title, job.Description, job.Cat.Name)
}

// Save link will probably be a constant
func SendKeyboard(job Job) tgbotapi.InlineKeyboardMarkup {
	return tgbotapi.NewInlineKeyboardMarkup(
		tgbotapi.NewInlineKeyboardRow(
			tgbotapi.NewInlineKeyboardButtonURL("Auto Apply \U00002705", job.Link),
			tgbotapi.NewInlineKeyboardButtonURL("Save \U0001F4BE", "www.example.com"),
		))
}

func GetJobs() []Job {
	var allItems []Job
	req, err := http.NewRequest("GET", apiLink, nil)
	if err != nil {
		log.Fatal(err)
	}
	// Add the x-api-key header
	req.Header.Set("x-api-key", apiKey)
	resp, err := http.DefaultClient.Do(req)
	if err != nil {
		log.Fatal(err)
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
