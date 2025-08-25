public class UltraVioletMachine : MachineScript
{
    private void Awake()
    {
        powerNeed = 5;
        powerGot = 0;
        bonus = 2;
        type = "speed"; // strength = memperbanyak hasil panen, speed = mempercepat pertumbuhan
    }
}
