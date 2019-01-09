using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ExceptionHandling.Domain;

namespace ExceptionHandling
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";

                // Calculate percentage of wins:
                decimal wins = decimal.Parse(gamesWonTextBox.Text);
                decimal total = decimal.Parse(totalGamesTextBox.Text);
                decimal winningPercentage = wins / total;

                result = $"Winning Percentage: {winningPercentage:P}";

                var monster = new Character() { Name = "Zerg", HitPoints = 0 };
                var hero = new Character() { Name = "Buzz", HitPoints = 5 };
                GameActions.Battle(hero, monster);
                result += $"{hero.Name} attacked {monster.Name} leaving him with {monster.HitPoints} hit points.";

                resultLabel.Text = result;
            }
            catch (Exception exception)
            {
                resultLabel.Text = $"There was a problem: {exception.Message}";
                //throw;
            }
        }
    }
}