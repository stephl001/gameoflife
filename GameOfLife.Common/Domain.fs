namespace GameOfLife.Common

module Domain =
    
    type Cell = Alive | Dead
    type Generation = Generation of Cell[,]

    type NextGeneration = Generation -> Generation

