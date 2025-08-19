using Notepad.Properties; // Biblioteca personalizada para os Strings de linguagens
using System; // Biblioteca padrao do .NET
using System.Drawing; // Biblioteca para o Icon
using System.IO; // Biblioteca para trabalhar com escrita e leitura de arquivos
using System.Windows.Forms; // Biblioteca para trabalhar com janelas e interface do Windows

namespace Notepad
{
    public partial class Program : Form
    {
        private TextBox TextBox;

        public Program()
        {
            this.Icon = new Icon("Ico.ico"); // Adiciona o Icon ao programa
            InitializeComponent(); // Chama o método de inicialização dos componentes
            LoadResolution();
        }
        // Métodos de manipulação de eventos de clique
        private void NewMenuItem_Click(object sender, EventArgs e) // "object sender, EventArgs e" sao obrigatorios
        {
            GC.Collect();
            var tabPage = new TabPage(Strings.TabNew);

            var newTextBox = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ScrollBars = ScrollBars.Both
            };

            tabPage.Controls.Add(newTextBox);
            TabControl.TabPages.Add(tabPage);
            TabControl.SelectedTab = tabPage;
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o aplicativo
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Text = Strings.TextAbout; // Exibe informações sobre o Notepad
        }

        private void HowToUseMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Text = Strings.TextHowToUse; // Exibe informações sobre como usar o Notepad
        }

        // Metodo para abrir o arquivo
        private void OpenFile(object sender, EventArgs e) // object sender, EventArgs e : sao obrigatorios para o metodo funcionar. Requerimentos do .NET
        {
            var activeTextBox = GetActiveTextBox();
            if (activeTextBox == null) return;

            using var ofd = new OpenFileDialog(); // Abre o file dialog(a janela do windows de abrir arquivos)
            if (ofd.ShowDialog() == DialogResult.OK) // Se ele confirmar o arquivo
            {
                using var reader = new StreamReader(ofd.FileName); // Utiliza o StreamReader do .NET (ele carrega as linhas individualmente ao invesdo arquivo inteiro, util para arquivos gigantes)
                activeTextBox.Text = reader.ReadToEnd(); // Faz com que o texto seja mostrado no textBox
                TabControl.SelectedTab.Text = Path.GetFileName(ofd.FileName);
                GC.Collect(); // Chama o Garbage Collector do .NET pra limpar memoria desnecessaria
            }
        }
        // Metodo para salvar o arquivo
        private void SaveFile(object sender, EventArgs e) // **
        {
            var activeTextBox = GetActiveTextBox(); // Utiliza a logica para "capturar" a textBox atual
            if (activeTextBox == null) return; // Se nao houver nenhuma textBox ativa cancela a execucao

            using var sfd = new SaveFileDialog(); // Abre o dialog do windows para salvar
            if (sfd.ShowDialog() == DialogResult.OK) //**
            {
                File.WriteAllText(sfd.FileName, activeTextBox.Text);
                TabControl.SelectedTab.Text = Path.GetFileName(sfd.FileName);
            }
        }

        private void LoadResolution()
        {
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

            screenBounds = Screen.PrimaryScreen.Bounds; // Garante a limpesa da variavel para o GC do .NET ou no pior dos casos uma variavel vazia.
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

        private TextBox GetActiveTextBox()
        {
            if (TabControl.SelectedTab != null && TabControl.SelectedTab.Controls.Count > 0)
            {
                foreach (Control c in TabControl.SelectedTab.Controls)
                {
                    if (c is TextBox tb)
                        return tb;
                }
            }
            return null;
        }

    }
}