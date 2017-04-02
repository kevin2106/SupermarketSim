module SimulationLogic

open Microsoft.Xna.Framework

type List<'a> = 
  | Empty 
  | Node of 'a * List<'a>
let (<<) x xs = Node(x,xs)

let rec toFSharpList l =
  match l with
  | Empty -> []
  | Node(x,xs) -> x :: toFSharpList xs


type Drawable = 
    { Position : Vector2
      Image : string }

type Obstacle = 
    { Position : Vector2 }

type GameState = 
    { Obstacles : seq<Obstacle> }
    //{ Registers : seq<Register>}

let initialState() = 
    { 
        Obstacles = 
          [ 
            { Position = Vector2(1.f, 1.f) }

            //registers
            { Position = Vector2(171.f, 826.f) }
            { Position = Vector2(510.f, 826.f) }
            { Position = Vector2(864.f, 826.f) } 


            //gangpaden
            { Position = Vector2(234.f, 121.f) } 
            { Position = Vector2(404.f, 121.f) } 
            { Position = Vector2(560.f, 121.f) } 
            { Position = Vector2(781.f, 121.f) } 

            { Position = Vector2(234.f, 180.f) } 
            { Position = Vector2(404.f, 180.f) } 
            { Position = Vector2(560.f, 180.f) } 
            { Position = Vector2(781.f, 180.f) } 
          ] 
    }

//let format:
//name (inputType) : outputType
// name (variable:Type) : returnValue
let drawObstacle (obstacle : Obstacle) : Drawable = 
    { Drawable.Position = obstacle.Position
      Drawable.Image = "obstacle" }

let drawInitialState (gameState : GameState) : seq<Drawable> =
    let listOfObstacles = Seq.map drawObstacle gameState.Obstacles 

    listOfObstacles
    