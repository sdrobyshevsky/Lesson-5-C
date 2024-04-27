// Разработка сетевого приложения на C# (семинары)
// Урок 5. Базы данных: Entity framework, code first/db first
// Реализуйте тип сообщений List, при котором клиент будет получать все непрочитанные сообщения с сервера.

// Подключаем необходимые библиотеки
using System;
using System.Collections.Generic;
using System.Linq;

// Определяем класс сообщения
public class Message
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsRead { get; set; }
}

// Определяем класс контекста базы данных
public class MessageContext : DbContext
{
    public DbSet<Message> Messages { get; set; }
}

// Создаем метод для получения всех непрочитанных сообщений клиента
public List<Message> GetUnreadMessages(int clientId)
{
    using (var context = new MessageContext())
    {
        List<Message> unreadMessages = context.Messages.Where(m => !m.IsRead && m.ClientId == clientId).ToList();
        return unreadMessages;
    }
}

// Пример использования метода
List<Message> unreadMessages = GetUnreadMessages(1);

// Выводим непрочитанные сообщения
foreach (var message in unreadMessages)
{
    Console.WriteLine(message.Text);
}