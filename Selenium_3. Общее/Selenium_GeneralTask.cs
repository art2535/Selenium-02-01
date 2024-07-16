using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium.Общее
{
    class Selenium_GeneralTask
    {
        static void Main(string[] args)
        {
            // Задание 1. Открой страницу https://qa-mesto.praktikum-services.ru/, а затем закрой браузер.
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://qa-mesto.praktikum-services.ru/");
            Console.WriteLine("\nСайт успешно открыт");

            /* Задание 2. На странице входа https://qa-mesto.praktikum-services.ru/ найди заголовок формы «Вход»:
             * это можно сделать с помощью CSS-селектора, используя класс. Закрой браузер. */
            IWebElement element = driver.FindElement(By.CssSelector(".auth-form__title"));
            Console.WriteLine($"\nЗаголовок формы - {element.Text}");

            // Задание 3. Найди все элементы с тэгом <img> по XPath. Примени относительный путь. Закрой браузер после тестирования.
            IList<IWebElement> images = driver.FindElements(By.XPath("//img"));
            Console.WriteLine($"\nНайдено изображений - {images.Count}");

            /* Задание 4. Найди кнопку «Войти» и кликни по ней — сделай это через поиск по XPath, используй класс и относительный путь.
             * Используй запись в одну строку, так ты не будешь создавать новый WebElement. */
            driver.FindElement(By.XPath(".//button[text()='Войти']")).Click();
            Console.WriteLine("\nКнопка нажата");

            /* Задание 5. Войди на сайт https://qa-mesto.praktikum-services.ru/ с помощью пользователя, 
             * которого тебе удалось создать в уроке про локаторы. Заполни поля «Email» и «Пароль» — используй поиск по id.
             * Кликни по кнопке «Войти» — используй поиск по классу.
             * Закрой браузер после тестирования. */
            driver.FindElement(By.Id("email")).SendKeys("artem010606@yandex.ru");
            driver.FindElement(By.Id("password")).SendKeys("gfhfuhfa3");
            driver.FindElement(By.ClassName("auth-form__button")).Click();
            Console.WriteLine("\nВход выполнен");

            // Задание 6. Найди кнопку выхода из профиля через поиск по имени класса. Получи текст кнопки и выведи на экран.
            Thread.Sleep(2000);
            string buttonText = driver.FindElement(By.ClassName("header__logout")).Text;
            Console.WriteLine("\nТекст кнопки выхода - " + buttonText);
            Console.WriteLine("\nВыход выполнен");

            driver.Quit();
            Console.WriteLine("\nСайт успешно закрыт\n");
        }
    }
}
