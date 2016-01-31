namespace familiada
{
	interface IOperatable
	{
		void PokażPanel(int który);
		void UkryjPanel(int który);
		void UstawPunktyGłówne(int punkty);
		void UstawPunktyDrużyny(int która, int punkty);
	}
}
