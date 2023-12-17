using System.Collections.Generic;

namespace GetOn.scenes {
    public class GameResult {
        public string Name { get; set; }
        public string SelectedSpecialization { get; set; }
        public List<ResultCategory> Categories { get; set; }
        public string TotalTime { get; set; }
        public string Hash { get; set; }
    }
}