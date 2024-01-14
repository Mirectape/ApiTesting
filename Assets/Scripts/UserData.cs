
//Поскольку по заданию не требовалось,
//я не стал ни хэшировать, ни использовать Json Parsing или БД
//для хранения данных пользователя, а просто использовал данный класс
public class UserData
{
    public string Login { get; } 
    public string Password { get; }

    public UserData() 
    {
        Login = "TestTaskUser ";
        Password = "TestUser123##";
    }
}
