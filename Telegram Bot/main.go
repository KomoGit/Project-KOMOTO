package main

import (
	"fmt"
	"log"
	"os"
	"strconv"

	tgbotapi "github.com/go-telegram-bot-api/telegram-bot-api/v5"
)

// var numericKeyboard = tgbotapi.NewInlineKeyboardMarkup(
// 	tgbotapi.NewInlineKeyboardRow(
// 		tgbotapi.NewInlineKeyboardButtonURL("Apply \U00002705", "example.com"),
// 		tgbotapi.NewInlineKeyboardButtonData("Save \U0001F4BE", "example.com"),
// 	),
// )

var chatId int64 = GetChatId(os.Getenv("TELEGRAM_CHAT_ID"))

type Job struct {
	title       string
	description string
	link        string
}

func main() {
	// var jobs []Job
	// Insert a sample job into the slice
	sampleJob := Job{
		title:       "Software Engineer",
		description: "Develop software applications.",
		link:        "google.com",
	}

	// // Append the sample job to the slice
	// jobs = append(jobs, sampleJob)

	bot, err := tgbotapi.NewBotAPI(os.Getenv("TELEGRAM_APITOKEN"))
	if err != nil {
		log.Panic(err)
	}

	bot.Debug = true
	log.Printf("Authorized on account %s", bot.Self.UserName)
	u := tgbotapi.NewUpdate(0)
	u.Timeout = 60

	updates := bot.GetUpdatesChan(u)

	// Loop through each update.
	for update := range updates {
		// Check if we've gotten a message update.
		if update.Message != nil {
			// Construct a new message from the given chat ID and containing
			// the text that we received.
			msg := tgbotapi.NewMessage(chatId, SendJob(sampleJob))
			msg.ReplyMarkup = SendKeyboard(sampleJob)
			// Send the message.
			if _, err = bot.Send(msg); err != nil {
				panic(err)
			}
		} else if update.CallbackQuery != nil {
			// Respond to the callback query, telling Telegram to show the user
			// a message with the data received.
			callback := tgbotapi.NewCallback(update.CallbackQuery.ID, update.CallbackQuery.Data)
			if _, err := bot.Request(callback); err != nil {
				panic(err)
			}

			// And finally, send a message containing the data received.
			msg := tgbotapi.NewMessage(update.CallbackQuery.Message.Chat.ID, update.CallbackQuery.Data)
			if _, err := bot.Send(msg); err != nil {
				panic(err)
			}
		}
	}
}

func GetChatId(envVar string) int64 {
	if n, err := strconv.ParseInt(envVar, 10, 64); err == nil {
		return n
	}
	return 0
}

func SendJob(job Job) string {
	return fmt.Sprintf("%s \n%s", job.title, job.description)
}

func SendKeyboard(job Job) tgbotapi.InlineKeyboardMarkup {
	return tgbotapi.NewInlineKeyboardMarkup(
		tgbotapi.NewInlineKeyboardRow(
			tgbotapi.NewInlineKeyboardButtonURL("Apply \U00002705", job.link),
			tgbotapi.NewInlineKeyboardButtonData("Save \U0001F4BE", "example.com"),
		))
}
