using QuizBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace QuizBot.UI;

internal class InlineMurkups
{
    public static InlineKeyboardMarkup GenerateQuestionWithAnswer(Root root)
    {
        InlineKeyboardMarkup inlineKeyboard = new(
            new[]
                {
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: root.answers.answer_a, callbackData: "a"),
                    InlineKeyboardButton.WithCallbackData(text: root.answers.answer_b, callbackData: "b"),
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: root.answers.answer_c, callbackData: "c"),
                    InlineKeyboardButton.WithCallbackData(text: root.answers.answer_d, callbackData: "d"),
                },
        });

        return inlineKeyboard;
    }

    public static InlineKeyboardMarkup GenerateQuizeYechasizmi()
    {
        InlineKeyboardMarkup inlineKeyboard = new(
            new[]
                {
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "OK", callbackData: "ok"),
                    InlineKeyboardButton.WithCallbackData(text: "NOT", callbackData: "no"),
                }
        });

        return inlineKeyboard;
    }
}
