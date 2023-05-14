using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kr_lib
{
    public class Machine
    {
        [Key]
        public int ID { get; set; }

        public string Model { get; set; }

        public double MaxWidth { get; set; }
        public double MaxHeight { get; set; }
        public double MaxLength { get; set; }

        public double ProcessingTimeOf1mm3 { get; set; }
        public decimal PriceOfProcessing1mm3 { get; set; }

        public LinkedList<Part> Parts { get; set; }
    }
}
