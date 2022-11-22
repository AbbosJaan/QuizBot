using QuizBot.Broker;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;
using System;
using Telegram.Bot.Exceptions;
using QuizBot.UI;
using QuizBot.Service;
using QuizBot.Model;

namespace QuizBot;

internal class Program
{
    private static int rightAnswersNumber=0;
    private static List<Root> data = ApiBroker.GetData();

    private static string Token = "5795662432:AAFsbV3bcv8rSQQ79qFpW-53H8_znCZ-M4k";

    private static int number = 0;


    static async Task Main()
    {
        var botClient = new TelegramBotClient(Token);

        using var cts = new CancellationTokenSource();
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };
        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        var me = await botClient.GetMeAsync();

        Console.WriteLine($"Start listening for @{me.Username}");
        Console.ReadLine();
        cts.Cancel();
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var handler = update switch
        {
            { Message: { } } => OnMessageText(),
            { CallbackQuery: { } } => OnCallbackQueryResived()
        };

        await handler;

        async Task OnMessageText()
        {
            Message message = update.Message;
            var chatId = update.Message.Chat.Id;

            Console.WriteLine($"'{message.Text}' deb yozyapti {message.Chat.FirstName}");


            MainView mainView = new MainView();

            if(message.Text == "/start")
            {
                await botClient.SendTextMessageAsync(
                    chatId:chatId,
                    text:$"Assalomu alaykum {message.Chat.FirstName}"
                );

                await mainView.SendOKNO(botClient,chatId,message.MessageId);
            }
        }

        async Task OnCallbackQueryResived()
        {
            string callback = update.CallbackQuery.Data;
            var chatId = update.CallbackQuery.Message.Chat.Id;
            var message = update.CallbackQuery.Message;

            if (number == 10)
            {
                await botClient.DeleteMessageAsync(
                    chatId: chatId,
                    messageId: message.MessageId
                );

                await botClient.SendTextMessageAsync(
                    chatId:chatId,
                    text:$"Qadrli {message.Chat.FirstName} \n Siz 10 savoldan {rightAnswersNumber} ta to'g'ri yechdingiz",
                    cancellationToken:cancellationToken
                );

                Console.WriteLine("Tamom");
            }else if (callback == "ok")
            {
                var mainView = new MainView();
                await mainView.SendQuestionWithAnswers(botClient, chatId, message.MessageId, data[number], number);
                number++;
            }
            else
            {
                var mainView = new MainView();
                if (callback == "a" && data[number].correct_answers.answer_a_correct == "true")
                {
                    rightAnswersNumber++;
                }
                else if (callback == "b" && data[number].correct_answers.answer_b_correct == "true")
                {
                    rightAnswersNumber++;
                }
                else if (callback == "c" && data[number].correct_answers.answer_c_correct == "true")
                {
                    rightAnswersNumber++;
                }
                else if (callback == "d" && data[number].correct_answers.answer_d_correct == "true")
                {
                    rightAnswersNumber++;
                }
                await botClient.DeleteMessageAsync(
                    chatId:chatId,
                    messageId:message.MessageId
                );

                await mainView.SendQuestionWithAnswers(botClient, chatId, message.MessageId, data[number], number);
                number++;
            }
        }
    }


    private static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}