using QuizBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace QuizBot.UI;

internal class MainView
{
    public async Task SendQuestionWithAnswers(ITelegramBotClient botClient,long chatId, int messageId, Root data,int number)
    {
        var QuestionWithAnswer = InlineMurkups.GenerateQuestionWithAnswer(data);

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"{number+1}-savol\n{data.question}",
            replyMarkup:QuestionWithAnswer
        );
    }


    public async Task SendOKNO(ITelegramBotClient botClient, long chatId, int messageId)
    {
        var QuestionWithAnswer = InlineMurkups.GenerateQuizeYechasizmi();

        await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Quize yechasizmi?",
            replyMarkup: QuestionWithAnswer
        );
    }
}
