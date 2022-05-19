﻿namespace DIContainer;


// DI контейнеры позволяют эффективно внедрять зависимости и управлять их жизненным циклом
// У нас будет упрощенная версия DI контейрета - без управления жизненным циклом (Singleton на экземпляр контейнера), и с авторегистрацией

// В чем профит DI контейнера?
// Вместо `var root = new Root(new Class1(), new Class2(new Class1(), new Class3()))`
// Можно будет написать 1 раз в начале `container.Configure<Root>()` - он построит дерево зависимостей
// а потом для получения корневого элемента вызывать `container.Get<Root>` (ну или для вложенного container.Get<Class2>) 
// Причем внутри дерева зависимостей их можно будет передавать через конструктор

// Гарантируется
// 1) У каждой зависимости(корневой и вложенной) только один конструктор (либо дефолтный)
// 2) Нет циклических зависимостей
// 3) в зависимостях только классы из текущей сборки (на них лучше и тестировать)
public class DIContainer
{
    public void Register<TInterface, T>()
    where T: class, TInterface
    {
        // Тут регистрируются исключения (если авторегистрация нас не устраивает)
    }
    public void Configure<T>() where T : class
    {
        // Инициализация
    }
    
    public T? Get<T>() where T : class
    {
        return null;
    }
}