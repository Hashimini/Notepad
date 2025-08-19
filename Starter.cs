using System; // Biblioteca padrao do .NET
using System.Globalization;
using System.Threading;
using System.Windows.Forms; // Biblioteca principal do windows forms


// A funcao de tudo aqui e inicializar o aplicativo
namespace Notepad
{
    static class Starter
    {
        [STAThread] // Requisito para que o notepad possa usar o clipboard, gerenciador de arquivos etc
        static void Main() // Executa tudo abaixo e consequentemente inicia a aplicacao
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture; // Verifica qual a regiao configurada no windows para selecionar a linguagem usada no app
            Application.EnableVisualStyles(); // Pede pro windows usar os styles modernos do win10 e win11
            Application.SetCompatibleTextRenderingDefault(false); // Utiliza o novo metodo de renderizacao de texto (GDI+) ao inves do antigo
            Application.Run(new Program()); // Faz com que abra o novo .cs (o principal do app)
        }
    }
}
