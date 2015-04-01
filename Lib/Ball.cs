using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class Ball
    {
        readonly Random _rand = new Random();
        readonly List<Answer> _answers = new List<Answer>();

        public event Action<string> SendMessage ;


        //счетчики
        private int _questionsCount, _answersCount, _positiveCount, _halfPositiveCount, _neutrlalCount, _negativeCount, _otherCount, _temp;
       
        //коеструктор
        public Ball()
        {
            if (SendMessage != null)
            {
                SendMessage("Желаете узнать ответ - задайте вопрос. Для выхода, напишите exit.");
            }

            foreach (var q in _positive.Select(st => new Answer(MessageType.Positive, st)))
            {
                _answers.Add(q);
            }

            foreach (var q in _halfPositive.Select(st => new Answer(MessageType.HalfPositive, st)))
            {
                _answers.Add(q);
            }

            foreach (var q in _neutral.Select(st => new Answer(MessageType.Neutral, st)))
            {
                _answers.Add(q);
            }

            foreach (var q in _negative.Select(st => new Answer(MessageType.Negative, st)))
            {
                _answers.Add(q);
            }
        }

        //Ответ
        private void GetAnswer()
        {
            _temp = _rand.Next(0, _answers.Count-1);
            if (SendMessage != null)
            {
                SendMessage(_answers[_temp].Message);
            }

            //обновление счетчиков
            switch (_answers[_temp].Type)
            {
                case MessageType.HalfPositive:
                    _halfPositiveCount++;
                    break;
                case MessageType.Negative:
                    _negativeCount++;
                    break;
                case MessageType.Neutral:
                    _neutrlalCount++;
                    break;
                case MessageType.Positive:
                    _positiveCount++;
                    break;
            }
        }

        //получение строки из консоли
        public void PutString(string str)
        {       
   
            try
            {
                if (IsAnswer(str))
                {
                    GetAnswer();
                    _questionsCount++;
                    _answersCount++;
                }
                else
                {
                    if (SendMessage != null)
                    {
                        SendMessage("Спросите меня о чем-либо. Я на все знаю ответ");
                    }
                    _otherCount++;
                }   
            }
            catch
            {
                if (SendMessage != null)
                {
                    SendMessage("Спросите меня о чем-либо. Я на все знаю ответ");
                }
                _otherCount++;
            }
        }

        //проверка последнего символа
        private static bool IsAnswer(string str)
        {
            var array = str.ToCharArray();
            return array[array.Length - 1] == '?';
        }

        //Вывод статистики
        private void GetStat()
        {
            Console.WriteLine("Количество вопросов - " + _questionsCount);
            Console.WriteLine("Количество других строк - " + _otherCount);
            Console.WriteLine("Количество ответов - " + _answersCount);
            Console.WriteLine("Количество положительных ответов - "+_positiveCount);
            Console.WriteLine("Количество отрицательных ответов - "+_negativeCount);
            Console.WriteLine("Количество условно-положительных ответов - "+_halfPositiveCount);
            Console.WriteLine("Количество нейтральных ответов - "+_neutrlalCount);        
        }

        #region варианты ответов
        readonly string[] _positive = {
            "It is certain (Бесспорно)",
            "It is decidedly so (Решено)",
            "Without a doubt (Никаких сомнений)",
            "Yes — definitely (Определённо да)",
            "You may rely on it (Можешь быть уверен в этом)"
        };

        readonly string[] _halfPositive = {
                "As I see it, yes (Мне кажется — «да»)",
                "Most likely (Вероятнее всего)",
                "Outlook good (Хорошие перспективы)",
                "Signs point to yes (Знаки говорят — «да»)",
                "Yes (Да)"
        };

        readonly string[] _neutral = {
                "Reply hazy, try again (Пока не ясно, попробуй снова)",
                "Ask again later (Спроси позже)",
                "Better not tell you now (Лучше не рассказывать)",
                "Cannot predict now (Сейчас нельзя предсказать)",
                "Concentrate and ask again (Сконцентрируйся и спроси опять)"
        };

        readonly string[] _negative = {
                "Don’t count on it (Даже не думай)",
                "My reply is no (Мой ответ — «нет»)",
                "My sources say no (По моим данным — «нет»)",
                "Outlook not so good (Перспективы не очень хорошие)"
        };
        #endregion
    }
}
