namespace MauiTicTacToe;

public partial class MainPage : ContentPage
{
	int counter; // counter = 0;
	bool O_playerTurn = true;
	Button[] buttons = new Button[9];
	int[,] tab = new int[3, 3]; //O->-1  &  X->1  // Win | 3 or -3

	public MainPage()
	{
		InitializeComponent();

        for (int i = 0; i < 9; i++) {
            buttons[i] = (Button)FindByName("btn" + (i + 1).ToString());
            //buttons[i].Clicked += btn_Clicked;
        }

	}

	private void clearButtons() 
	{
		for (int i = 0; i < 9; i++)
			buttons[i].Text = "";

    }

	private void disableButtons()
	{
        for (int i = 0; i < 9; i++)
            buttons[i].IsEnabled= false;
    }
    private void enableButtons()
    {
        for (int i = 0; i < 9; i++)
            buttons[i].IsEnabled = true;
    }

	private void resetTable()
	{
		for(int i=0; i < tab.GetLength(0);i++)
			for(int j=0; j < tab.GetLength(1); j++)
				tab[i,j] = 0;
	}

    private void btnStartNewGame_Clicked(object sender, EventArgs e)
    {
        clearButtons();
        enableButtons();
        resetTable();
        counter = 0;
        O_playerTurn = true;
        LabInfo.Text = "";
    }

	private int checkSum()
	{
		int sum;
		for(int i = 0; i < tab.GetLength(0); i++)//Rows
		{
			sum = 0;
			for(int j = 0; j < tab.GetLength(1); j++)
				sum += tab[i,j];

			if ((sum == 3) || (sum == -3))
				return sum;
		}

        for (int j = 0; j < tab.GetLength(0); j++)//Columns
        {
            sum = 0;
            for (int i = 0; i < tab.GetLength(1); i++)
                sum += tab[i, j];

            if ((sum == 3) || (sum == -3))
                return sum;
        }

		sum = tab[0, 0] + tab[1, 1] + tab[2, 2];//First diagonal
        if ((sum == 3) || (sum == -3))
            return sum;

        sum = tab[0, 2] + tab[1, 1] + tab[2, 0];//Second diagonal
        if ((sum == 3) || (sum == -3))
            return sum;


        return 0;
	}

	private void btn_Clicked(object sender, EventArgs e)
	{
        if(counter < 9) {
            int j, k; // j - row index , k - column index

            for(int i = 0; i < buttons.Length; i++)
                if (sender.Equals(buttons[i]))
                {
                    if(i < 3) { j = 0; k = i; } // first row of tab (2 dimensional table)
                    else if (i < 6) { j = 1; k = i-3; } // second row of tab
                    else { j = 2; k = i - 6; } // third row of tab

                    if (O_playerTurn)
                    {
                        buttons[i].Text = "O"; O_playerTurn = false; tab[j, k] = -1;
                    }
                    else
                    {
                        buttons[i].Text = "X"; O_playerTurn = true; tab[j, k] = 1;
                    }

                    buttons[i].IsEnabled = false;
                    buttons[i].TextColor = Color.FromArgb("#000000");
                    counter++;
                    int result = checkSum();

                    if (result == 3) { disableButtons(); LabInfo.Text = "X-player has won!"; return; }
                    else if (result == -3) { disableButtons(); LabInfo.Text = "O-player has won!"; return; }
                    
                    if (counter == 9) LabInfo.Text = "Game over - No winners!"; 
                    
                    return; 
                    
                }

        }
    }

    /*private void btn2_Clicked(object sender, EventArgs e)
    {
        if(counter < 9) { 
            if (O_playerTurn)
            {
                btn2.Text = "O"; tab[0, 0] = -1;
            }
            else
            {
                btn2.Text = "X"; tab[0, 0] = 1;
            }
            btn2.IsEnabled = false;
            counter++;
            int result = checkSum();
            if (result == 3) { disableButtons(); LabInfo.Text = "X-player has won!"; return; }
            else if (result == -3) { disableButtons(); LabInfo.Text = "O-player has won!"; return; }
            else
            {
                if (counter == 9) { LabInfo.Text = "Game is over - No one wins !"; return; }
            }
        }

    }*/

    
}

