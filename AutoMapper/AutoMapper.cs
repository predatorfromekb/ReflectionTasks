namespace AutoMapper;

// Автомапперы проецируют одну модель на другую, что позволяет сократить объемы кода и упростить программу.
// При этом, логику проекции они инкапсулируют внутри себя.
// Смотри проект с тестами и заставь их проходить :)
public static class AutoMapper
{
    public static TResult? Map<T, TResult>(T? item) 
        where T : class, new()
        where TResult : class, new()
    {
        return null;
    }
}