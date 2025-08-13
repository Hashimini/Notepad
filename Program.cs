using Notepad.Properties; // Biblioteca personalizada para os Strings de linguagens
using System; // Biblioteca padrao do .NET
using System.Drawing; // Biblioteca para o Icon
using System.IO; // Biblioteca para trabalhar com escrita e leitura de arquivos
using System.Windows.Forms; // Biblioteca para trabalhar com janelas e interface do Windows

namespace Notepad
{
    public class Program : Form
    {
        private TextBox textBox;

        public Program()
        {
            this.Icon = new Icon("Ico.ico"); // Adiciona o Icon ao programa
            StartComponents(); // Chama o metodo principal do programa
        }

        private void StartComponents()
        {
            this.Text = "Notepad"; // Define o nome da Janela

            var screenBounds = Screen.PrimaryScreen.Bounds; // Cria uma variavel com o limite da tela do0 usuario

            // Faz a verificacao se a posicao da janela no X e Y + O tamanho no X e no Y eh maior que o limite da tela no X ou no Y
            if (Settings.Default.WindowXpos < screenBounds.Left ||
                Settings.Default.WindowYpos < screenBounds.Top ||
                Settings.Default.WindowXpos + Settings.Default.WindowWidth > screenBounds.Right ||
                Settings.Default.WindowYpos + Settings.Default.WindowHeight > screenBounds.Bottom)
            {
                this.StartPosition = FormStartPosition.CenterScreen; // Volta pro centro da tela se for verdadeiro
            }
            else
            {
                // Se nao vai usar as configuracoes persistentes que estavam salvas
                this.Width = Settings.Default.WindowWidth;
                this.Height = Settings.Default.WindowHeight;
                this.Left = Settings.Default.WindowXpos;
                this.Top = Settings.Default.WindowYpos;
            }

            textBox = new TextBox // Cria uma caixa de texto com as especificacoes abaixo
            {
                Multiline = true, // Permite usar varias linhas
                Dock = DockStyle.Fill, // Faz com que ocupe toda a janela
                ScrollBars = ScrollBars.Both // Adicione as barras de scroll, a horizontal e vertical
            };

            var menuStrip = new MenuStrip(); // Cria um menu meio que de cascata na janela

            // Cria os itens do menu em variaveis que serao adicionadas depois
            // Todos os arquivos utilizam o "Strings" que tem os arquivos com as traducoes especificas.
            var File = new ToolStripMenuItem(Strings.MenuFile);
            var New = new ToolStripMenuItem(Strings.MenuNew, null, (s, e) => textBox.Clear()); // Faz com que esse Strip limpe o texbox criado anteriormente
            var Open = new ToolStripMenuItem(Strings.MenuOpen, null, OpenFile); // Chama o metodo OpenFile
            var Save = new ToolStripMenuItem(Strings.MenuSave, null, SaveFile); // Chama o metodo SaveFile
            var Exit = new ToolStripMenuItem(Strings.MenuClose, null, (s, e) => Close()); // Faz a aplicacao fechar

            // Cria as variaveis que serao usadas no menu e os valores delas
            var Help = new ToolStripMenuItem(Strings.MenuHelp);
            var About = new ToolStripMenuItem(Strings.MenuAbout, null, (s, e) =>
            {
                textBox.Text = Strings.TextAbout; // Da display no texto
            });

            var HowToUse = new ToolStripMenuItem(Strings.MenuHowToUse, null, (s, e) =>
            {
                textBox.Text = Strings.TextHowToUse; // **
            });

            // Aqui ele adiciona oque ja foram criados nas variaveis acima no menuStrip
            File.DropDownItems.Add(New);
            File.DropDownItems.Add(Open);
            File.DropDownItems.Add(Save);
            File.DropDownItems.Add(new ToolStripSeparator());
            File.DropDownItems.Add(Exit);

            // **
            Help.DropDownItems.Add(About);
            Help.DropDownItems.Add(new ToolStripSeparator());
            Help.DropDownItems.Add(HowToUse);

            menuStrip.Items.Add(File); // Cria o menuStrip principal, o botao
            menuStrip.Items.Add(Help); // **


            // Aqui ele adiciona os itens na janela, anteriormente tinha sido somente a logica
            this.MainMenuStrip = menuStrip; // Define que menuStrip sera o menu principal da janela
            this.Controls.Add(textBox); // Finalmente adiciona a textBox na janela
            this.Controls.Add(menuStrip); // Adiciona o menuStrip na janela
        }

        // Metodo para abrir o arquivo
        private void OpenFile(object sender, EventArgs e) // object sender, EventArgs e : sao obrigatorios para o metodo funcionar. Requerimentos do .NET
        {
            using var ofd = new OpenFileDialog(); // Abre o file dialog (a janela do windows de abrir arquivos)
            if (ofd.ShowDialog() == DialogResult.OK) // Se ele confirmar o arquivo
            {
                textBox.Clear(); // Limpa o texto (anterior)
                GC.Collect(); // Chama o Garbage Collector do .NET pra limpar memoria desnecessaria
                using var reader = new StreamReader(ofd.FileName); // Utiliza o StreamReader do .NET (ele carrega as linhas individualmente ao invesdo arquivo inteiro, util para arquivos gigantes)
                textBox.Text = reader.ReadToEnd(); // Faz com que o texto seja mostrado no textBox
            }
        }

        private void SaveFile(object sender, EventArgs e) // **
        {
            using var sfd = new SaveFileDialog(); // **
            if (sfd.ShowDialog() == DialogResult.OK) // **
            {
                File.WriteAllText(sfd.FileName, textBox.Text); // Aqui ele salva o texto da textbox no arquivo que foi criado.
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) // Metodo chamado quando o Form for fechado (quando o usuario fechar o app normalmente)
        {
            // Faz as alteracoes no arquivo Settings com os valores atuais
            Settings.Default.WindowWidth = this.Width;
            Settings.Default.WindowHeight = this.Height;
            Settings.Default.WindowXpos = this.Left;
            Settings.Default.WindowYpos = this.Top;

            Settings.Default.Save(); // Salva no disco as alteracoes
            base.OnFormClosing(e);
        }

    }
}
