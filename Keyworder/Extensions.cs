using System.Windows.Forms;

namespace Keyworder
{
    public static class Extensions
    {
        public static string CleanText(this TextBox textBox)
        {
            const string doubleSpace = "  ";
            const string space = " ";
            return textBox.Text.Trim().Replace(doubleSpace, space);
        }

        public static bool HasText(this TextBox textBox)
        {
            return !string.IsNullOrWhiteSpace(textBox.CleanText());
        }

        public static bool HasSelection(this ComboBox comboBox)
        {
            return !string.IsNullOrWhiteSpace(comboBox.SelectedItem?.ToString());
        }
    }
}
