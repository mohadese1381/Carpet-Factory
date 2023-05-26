using CarpetFactory;

UserPanel userPanel = new UserPanel();
for (int i = 0; i < 10; i++)
{
    FactoryManager.allCarpets.Add(new Carpet());
}
while (true)
{
    userPanel.showMenu();
}