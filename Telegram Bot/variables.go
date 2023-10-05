package main

import (
	"os"
	"time"
)

var (
	chatId  int64  = GetChatId(os.Getenv("CHAT_ID")) //Converts to int64
	apiLink string = os.Getenv("API_LINK")           //Single api link will be split into multiple and stored in array
	apiKey  string = os.Getenv("API_KEY")
)

const SLEEP_DURATION = time.Second * time.Duration(10) //10 Seconds
