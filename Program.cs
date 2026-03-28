using System;

void CheckForQuit(string? input) {
    if (input?.ToLower() == "конец") {
        Environment.Exit(0);
    }
}

Console.Write("Введите марку автомобиля или конец для остановки ввода: ");

while (true) {
    string? input = Console.ReadLine();
    
    CheckForQuit(input);
    
    if (string.IsNullOrWhiteSpace(input)) {
        continue;
    }

    CarType type;
    if (!Enum.TryParse(input, true, out type)) {
        Console.Write("Программа: «описание авто»\n");
        Console.Write("Введите марку автомобиля или конец для остановки ввода: ");
        continue;
    }

    ICar car = CarFactory.CreateCar(type);
    Console.Write($"Программа: «{car.GetDescription()}»\n");
    Console.Write("Введите марку автомобиля или конец для остановки ввода:");
}
