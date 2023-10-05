package main

import (
	"os"
	"strconv"
	"strings"
)

func SplitData(link string) []string {
	return strings.Split(link, " ")
}

func getEnvBool() bool {
	return strings.ToLower(os.Getenv("DEBUG_MODE")) == "true"
}

func GetChatId(str string) int64 {
	if n, err := strconv.ParseInt(str, 10, 64); err == nil {
		return n
	}
	return 0
}
