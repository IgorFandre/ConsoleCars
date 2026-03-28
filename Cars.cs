public enum CarType {
    Tesla,
    Toyota,
    Lada,
    Geely
}

public interface ICar {
    string GetDescription();
}

public interface IElectric {}
public interface IMechanical {}

public interface IMechanicalGearbox {} 
public interface IAutomaticalGearbox {}

public abstract class ACar : ICar {
    public string Brand { get; set; } = string.Empty;
    public int Seats { get; set; } = 5;

    public virtual string GetDescription() {
        return $"{Brand}: ";
    }
}

public abstract class AElectricCar : ACar, IElectric {
    public override string GetDescription() {
        return base.GetDescription() + "электрический автомобиль с ";
    }
}

public abstract class AMechanicalCar : ACar, IMechanical {
    public override string GetDescription() {
        return base.GetDescription() + "механический автомобиль с ";
    }
}

public abstract class AAutomaticElectricCar : AElectricCar, IAutomaticalGearbox {
    public override string GetDescription() {
        return base.GetDescription() + "автоматической коробкой передач, ";
    }
}

public abstract class AManualMechanicalCar : AMechanicalCar, IMechanicalGearbox {
    public override string GetDescription() {
        return base.GetDescription() + "механической коробкой передач, ";
    }
}

public abstract class AAutomaticMechanicalCar : AMechanicalCar, IAutomaticalGearbox {
    public override string GetDescription() {
        return base.GetDescription() + "автоматической коробкой передач, ";
    }
}

public class Lada : AManualMechanicalCar {
    public Lada() { 
        Brand = "Lada"; 
        Seats = 5; 
    }
    public override string GetDescription() {
        return base.GetDescription() + $"{Seats} местами, без кондиционера";
    }
}

public class Tesla : AAutomaticElectricCar {
    public Tesla() { 
        Brand = "Tesla"; 
        Seats = 5; 
    }
    public override string GetDescription() {
        return base.GetDescription() + $"{Seats} местами, ИИ-ассистентом";
    }
}

public class Toyota : AAutomaticMechanicalCar {
    public Toyota() { 
        Brand = "Toyota"; 
        Seats = 4; 
    }
    public override string GetDescription() {
        return base.GetDescription() + $"{Seats} местами, современным дизайном";
    }
}

public class Geely : AAutomaticMechanicalCar {
    public Geely() { 
        Brand = "Geely"; 
        Seats = 5; 
    }
    public override string GetDescription() {
        return base.GetDescription() + $"{Seats} местами, современным мултимедиа";
    }
}

public static class CarFactory {
    public static ICar CreateCar(CarType type) {
        switch (type) {
            case CarType.Tesla: return new Tesla();
            case CarType.Toyota: return new Toyota();
            case CarType.Lada: return new Lada();
            case CarType.Geely: return new Geely();
            default: throw new Exception("Неизвестный тип автомобиля");
        }
    }
}
