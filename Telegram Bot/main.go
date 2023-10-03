package main

import (
	"encoding/json"
	"fmt"
	"log"
	"net/http"
	"os"
	"strconv"
	"strings"
	"time"

	tgbotapi "github.com/go-telegram-bot-api/telegram-bot-api/v5"
)

// Constants and environment variables
var (
	chatId  int64  = GetChatId(os.Getenv("CHAT_ID")) //Converts to int64
	apiLink string = os.Getenv("API_LINK")
	apiKey  string = os.Getenv("API_KEY")
)

const SLEEP_DURATION = time.Second * time.Duration(10) //10 Seconds

// Data binding
type Category struct {
	Name string `json:"name"`
	ID   int    `json:"id"`
}
type Company struct {
	Name     string `json:"name"`
	Industry string `json:"industry"`
}
type Job struct {
	ID          int      `json:"id"`
	Title       string   `json:"title"`
	Description string   `json:"description"`
	Link        string   `json:"link"`
	ExpDate     string   `json:"expirationDate"`
	CategoryID  int      `json:"categoryId"`
	Cat         Category `json:"jobCategory"`
	CompanyID   int      `json:"employerId"`
	Employer    Company  `json:"employer"`
}

func main() {
	//Burst of 5
	i := 0
	for _, item := range GetJobs() {
		if i == 4 {
			time.Sleep(SLEEP_DURATION)
			fmt.Printf("Burst of %d is done\n", i)
			i = 0
		}
		BotController(item)
		i++
	}
}

func BotController(job Job) {
	bot, err := tgbotapi.NewBotAPI(os.Getenv("BOT_TOKEN"))
	if err != nil {
		log.Panic(err)
	}

	bot.Debug = getEnvBool()
	u := tgbotapi.NewUpdate(0)
	u.Timeout = 60

	msg := tgbotapi.NewMessage(chatId, SendJob(job))
	msg.ReplyMarkup = SendKeyboard(job)
	// Send the message.
	if _, err = bot.Send(msg); err != nil {
		panic(err)
	}
}

// Parsers
func GetChatId(str string) int64 {
	if n, err := strconv.ParseInt(str, 10, 64); err == nil {
		return n
	}
	return 0
}

func getEnvBool() bool {
	return strings.ToLower(os.Getenv("DEBUG_MODE")) == "true"
}

// Send Data
func SendJob(job Job) string {
	return fmt.Sprintf("Title: %s\nDescription: %s\nCompany: %s\nCategory: %s\nExpiration Date: %s", job.Title, job.Description, job.Employer.Name, job.Cat.Name, strings.Split(job.ExpDate, "T")[0])
}

func SendKeyboard(job Job) tgbotapi.InlineKeyboardMarkup {
	return tgbotapi.NewInlineKeyboardMarkup(
		tgbotapi.NewInlineKeyboardRow(
			tgbotapi.NewInlineKeyboardButtonURL("Auto Apply \U00002705", job.Link),
			tgbotapi.NewInlineKeyboardButtonURL("Save \U0001F4BE", "www.example.com"), // Save link will probably be a constant
		))
}

// Retireve Data
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
