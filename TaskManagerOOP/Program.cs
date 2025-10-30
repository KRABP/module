using System;
using System.Windows.Forms;

namespace TaskManagerOOP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Console.WriteLine("Application starting..."); // Для отладки

                // Создаем репозиторий и сервис отдельно для диагностики
                try
                {
                    var repository = new TaskRepository();
                    Console.WriteLine("Repository created successfully");

                    var service = new TaskService(repository);
                    Console.WriteLine("Service created successfully");

                    var form = new MainForm();
                    Console.WriteLine("Form created successfully");

                    Application.Run(form);
                }
                catch (Exception innerEx)
                {
                    MessageBox.Show($"Error creating dependencies: {innerEx.Message}\n\nStack trace: {innerEx.StackTrace}",
                        "Dependency Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start application: {ex.Message}\n\nStack trace: {ex.StackTrace}",
                    "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}