using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium.Индивидуальное
{
    internal class Selenium_IndividualTask
    {
        static void Main(string[] args)
        {
            /* Индивидуальное задание. Автоматизировать не менее 5-ти законченных действий пользователя на одном из сайтов:
             * https://qa-scooter.praktikum-services.ru/
             * например:
             * Вход в систему (Войти -> Заполнить поля -> Нажать на кнопку «Войти»)
             * Регистрация
             * Редактировать профиль
             * Сделать заказ и т. д. */
            // Отключаем DevTools
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-extensions");

            // Открываем сайт
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://qa-scooter.praktikum-services.ru/");
            Console.WriteLine("\nСайт успешно открыт");

            // Нажатие кнопки "Заказать"
            driver.FindElement(By.ClassName("Button_Button__ra12g")).Click();
            Console.WriteLine("\nКнопка \"Заказать\" нажата");

            // Заполнение данными формы. Страница 1
            driver.FindElement(By.CssSelector("input[placeholder='* Имя']")).SendKeys("Артем");
            driver.FindElement(By.CssSelector("input[placeholder='* Фамилия']")).SendKeys("Петров");
            driver.FindElement(By.CssSelector("input[placeholder='* Адрес: куда привезти заказ']")).SendKeys("ул. Новый Арбат");
            driver.FindElement(By.CssSelector("input[placeholder='* Станция метро']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement metroList = wait.Until(d => d.FindElement(By.CssSelector(".select-search__input")));
            metroList.SendKeys("Сокольники");
            IWebElement option = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(), 'Сокольники')]")));
            option.Click();
            IWebElement phoneInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[placeholder='* Телефон: на него позвонит курьер']")));
            phoneInput.SendKeys("+79215567427");
            driver.FindElement(By.XPath(".//button[text()='да все привыкли']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(".//button[text()='Далее']")).Click();
            Console.WriteLine("\nСтраница 1 формы заполнена");
            Console.WriteLine("\nКнопка \"Далее\" нажата");

            // Заполнение данными формы. Страница 2
            IWebElement datePickerInput = driver.FindElement(By.CssSelector("input[placeholder='* Когда привезти самокат']"));
            datePickerInput.SendKeys("13.05.2024");
            datePickerInput.Click();
            datePickerInput.SendKeys(Keys.Enter);
            driver.FindElement(By.XPath(".//div[@class='Dropdown-control']")).Click();
            IWebElement time = driver.FindElement(By.CssSelector(".Dropdown-menu > div:nth-child(1)"));
            time.Click();
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[3]/button[2]")).Click();
            Console.WriteLine("\nСтраница 2 формы заполнена");
            Console.WriteLine("\nКнопка \"Заказать\" нажата");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[5]/div[2]/button[2]")).Click();
            Console.WriteLine("\nКнопка \"Да\" нажата");

            // Закрытие сайта
            Thread.Sleep(2000);
            driver.Quit();
            Console.WriteLine("\nСайт успешно закрыт");
        }
    }
}
