module SupermarketSimulation

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

let initialState() = 
    { 
        Obstacles = 
          [ { Position = Vector2(12.f, 12.f) }
            { Position = Vector2(52.f, 32.f) } 
          ] 
    }

//let format:
//name (inputType) : outputType
// name (variable:Type) : returnValue
let drawObstacle (obstacle : Obstacle) : Drawable = 
    { Drawable.Position = obstacle.Position
      Drawable.Image = "obstacle.png" }

let drawInitialState (gameState : GameState) : seq<Drawable> =
    let listOfObstacles = Seq.map gameState.Obstacles drawObstacle

    listOfObstacles
    
//return list with all static drawings
//input: ?   output: list of all static drawings
//let drawSuperMarket () : seq<Drawable> =
//let drawState (gameState : GameState) : seq<Drawable> = 
//    let listOfDrawableProjectiles = map drawProjectile gameState.Projectiles |> toFSharpList
//    let listOfDrawableEnemies = map drawEnemy gameState.Enemies |> toFSharpList
//    [ { Drawable.Position = gameState.Ship.Position
//        Drawable.Image = "spaceShip.png" } ] @ listOfDrawableEnemies @ listOfDrawableProjectiles |> Seq.ofList
