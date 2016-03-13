namespace familiada
{
	interface IOperatable
	{
		void ShowPanel(int który);
		void HidePanel(int który);
		void SetMainPoints(int punkty);
		void SetTeamPoints(int która, int punkty);
	}
}
