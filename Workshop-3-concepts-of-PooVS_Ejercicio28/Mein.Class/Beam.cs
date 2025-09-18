namespace LaVigaMasResistente
{
    public  class Beam
    {
        private string beamString;
        private bool isValid;
        private int resistance;
        private int weight;

        public Beam(string beamString)
        {
            this.beamString = beamString;
            this.isValid = false;
            this.resistance = 0;
            this.weight = 0;
        }

 
        public void Analyze()
        {
            // se valida la viga
            BeamValidator validator = new BeamValidator();
            isValid = validator.Validate(beamString);

            if (!isValid) return;

            // se realiza para calcular el peso de la viga 
            WeightCalculator calculator = new WeightCalculator();
            weight = calculator.CalculateTotalWeight(beamString);

            // se obtiene la resistencia de la viga 
            resistance = calculator.GetBaseResistanceFromChar(beamString[0]);
        }

        public string GetResult()
        {
            if (!isValid)
            {
                return "La viga está mal construida!";
            }

            if (weight <= resistance)
            {
                return "La viga soporta el peso!";
            }
            else
            {
                return "La viga NO soporta el peso!";
            }
        }
    }
}