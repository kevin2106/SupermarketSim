module SimulationLogic

open Microsoft.Xna.Framework

let r = new System.Random()

type ShoppingItem = {
    Position : Vector2
}

type ShoppingItems = {
    Items : seq<ShoppingItem>
}

let initShoppingItems = {
    Items =
        [
            {Position = Vector2(34.f,34.f)}
            {Position = Vector2(34.f,34.f)}
            {Position = Vector2(34.f,34.f)}
            {Position = Vector2(34.f,34.f)}
            {Position = Vector2(34.f,34.f)}
        ]
}

//let getRandomShoppingItem (shoppingItemsList : ShoppingItems) : ShoppingItem = {
//    Seq.take 2 shoppingItemsList.Items
     
//}
        

type Drawable = 
    { Position : Vector2
      Image : string }

type Obstacle = 
    { Position : Vector2 }

type CustomerPathFinding = Vector2 * int


type Customer = 
    {
        Position: Vector2
        ShoppingListCount : int
        CurrentItemLocation : Vector2
        nextWaypoint: CustomerPathFinding
    }

type GameState = 
    {   
        Obstacles : seq<Obstacle>
        Customers : seq<Customer>
    }

let initialState() = 
    { 
        Customers = []
        Obstacles = 
          [ 
            //North wall
            { Position = Vector2(1.f, 1.f) }    
            { Position = Vector2(32.f, 1.f) }
            { Position = Vector2(64.f, 1.f) }
            { Position = Vector2(96.f, 1.f) }
            { Position = Vector2(128.f, 1.f) }
            { Position = Vector2(160.f, 1.f) }
            { Position = Vector2(192.f, 1.f) }
            { Position = Vector2(224.f, 1.f) }
            { Position = Vector2(256.f, 1.f) }
            { Position = Vector2(288.f, 1.f) }
            { Position = Vector2(320.f, 1.f) }
            { Position = Vector2(352.f, 1.f) }
            { Position = Vector2(384.f, 1.f) }
            { Position = Vector2(416.f, 1.f) }
            { Position = Vector2(448.f, 1.f) }
            { Position = Vector2(480.f, 1.f) }
            { Position = Vector2(512.f, 1.f) }
            { Position = Vector2(544.f, 1.f) }
            { Position = Vector2(576.f, 1.f) }
            { Position = Vector2(608.f, 1.f) }
            { Position = Vector2(640.f, 1.f) }
            { Position = Vector2(672.f, 1.f) }
            { Position = Vector2(704.f, 1.f) }
            { Position = Vector2(736.f, 1.f) }
            { Position = Vector2(768.f, 1.f) }
            { Position = Vector2(800.f, 1.f) }
            { Position = Vector2(832.f, 1.f) }
            { Position = Vector2(864.f, 1.f) }
            { Position = Vector2(896.f, 1.f) }
            { Position = Vector2(928.f, 1.f) }
            { Position = Vector2(960.f, 1.f) }
            { Position = Vector2(992.f, 1.f) }
            
            //South wall
            { Position = Vector2(1.f, 992.f) }    
            { Position = Vector2(32.f, 992.f) }
            { Position = Vector2(64.f, 992.f) }
            { Position = Vector2(96.f, 992.f) }
            { Position = Vector2(128.f, 992.f) }
            { Position = Vector2(160.f, 992.f) }
            { Position = Vector2(192.f, 992.f) }
            { Position = Vector2(224.f, 992.f) }
            { Position = Vector2(256.f, 992.f) }
            { Position = Vector2(288.f, 992.f) }
            { Position = Vector2(320.f, 992.f) }
            { Position = Vector2(352.f, 992.f) }
            { Position = Vector2(384.f, 992.f) }
            { Position = Vector2(608.f, 992.f) }
            { Position = Vector2(640.f, 992.f) }
            { Position = Vector2(672.f, 992.f) }
            { Position = Vector2(704.f, 992.f) }
            { Position = Vector2(736.f, 992.f) }
            { Position = Vector2(768.f, 992.f) }
            { Position = Vector2(800.f, 992.f) }
            { Position = Vector2(832.f, 992.f) }
            { Position = Vector2(864.f, 992.f) }
            { Position = Vector2(896.f, 992.f) }
            { Position = Vector2(928.f, 992.f) }
            { Position = Vector2(960.f, 992.f) }
            { Position = Vector2(992.f, 992.f) }

            //EAST wall
            { Position = Vector2(992.f, 1.f) }    
            { Position = Vector2(992.f, 32.f) }
            { Position = Vector2(992.f, 64.f) }
            { Position = Vector2(992.f, 96.f) }
            { Position = Vector2(992.f , 128.f) }
            { Position = Vector2(992.f, 160.f) }
            { Position = Vector2(992.f, 192.f) }
            { Position = Vector2(992.f, 224.f) }
            { Position = Vector2(992.f, 256.f) }
            { Position = Vector2(992.f, 288.f) }
            { Position = Vector2(992.f, 320.f) }
            { Position = Vector2(992.f, 352.f) }
            { Position = Vector2(992.f, 384.f) }
            { Position = Vector2(992.f, 416.f) }
            { Position = Vector2(992.f, 448.f) }
            { Position = Vector2(992.f, 480.f) }
            { Position = Vector2(992.f, 512.f) }
            { Position = Vector2(992.f, 544.f) }
            { Position = Vector2(992.f, 576.f) }
            { Position = Vector2(992.f, 608.f) }
            { Position = Vector2(992.f, 640.f) }
            { Position = Vector2(992.f, 672.f) }
            { Position = Vector2(992.f, 704.f) }
            { Position = Vector2(992.f, 736.f) }
            { Position = Vector2(992.f, 768.f) }
            { Position = Vector2(992.f, 800.f) }
            { Position = Vector2(992.f, 832.f) }
            { Position = Vector2(992.f, 864.f) }
            { Position = Vector2(992.f, 896.f) }
            { Position = Vector2(992.f, 928.f) }
            { Position = Vector2(992.f, 960.f) }
            { Position = Vector2(992.f, 992.f) }

            //WEST WALL
            { Position = Vector2(1.f, 160.f) }
            { Position = Vector2(1.f, 192.f) }
            { Position = Vector2(1.f, 224.f) }
            { Position = Vector2(1.f, 256.f) }
            { Position = Vector2(1.f, 288.f) }
            { Position = Vector2(1.f, 320.f) }
            { Position = Vector2(1.f, 352.f) }
            { Position = Vector2(1.f, 384.f) }
            { Position = Vector2(1.f, 416.f) }
            { Position = Vector2(1.f, 448.f) }
            { Position = Vector2(1.f, 480.f) }
            { Position = Vector2(1.f, 512.f) }
            { Position = Vector2(1.f, 544.f) }
            { Position = Vector2(1.f, 576.f) }
            { Position = Vector2(1.f, 608.f) }
            { Position = Vector2(1.f, 640.f) }
            { Position = Vector2(1.f, 672.f) }
            { Position = Vector2(1.f, 704.f) }
            { Position = Vector2(1.f, 736.f) }
            { Position = Vector2(1.f, 768.f) }
            { Position = Vector2(1.f, 800.f) }
            { Position = Vector2(1.f, 832.f) }
            { Position = Vector2(1.f, 864.f) }
            { Position = Vector2(1.f, 896.f) }
            { Position = Vector2(1.f, 928.f) }
            { Position = Vector2(1.f, 960.f) }
            { Position = Vector2(1.f, 992.f) }

            //registers
            { Position = Vector2(171.f, 864.f) }
            { Position = Vector2(510.f, 864.f) }
            { Position = Vector2(864.f, 864.f) } 


            //gangpaden
            //rij1
            { Position = Vector2(224.f, 192.f) } 
            { Position = Vector2(224.f, 224.f) }
            { Position = Vector2(224.f, 256.f) }
            { Position = Vector2(224.f, 288.f) }
            { Position = Vector2(224.f, 320.f) }
            { Position = Vector2(224.f, 352.f) }
            { Position = Vector2(224.f, 384.f) }
            { Position = Vector2(224.f, 416.f) }
            { Position = Vector2(224.f, 448.f) }
            { Position = Vector2(224.f, 480.f) }
            { Position = Vector2(224.f, 512.f) }
            { Position = Vector2(224.f, 544.f) }
            { Position = Vector2(224.f, 576.f) }
            { Position = Vector2(224.f, 608.f) }
            { Position = Vector2(224.f, 640.f) }
            { Position = Vector2(224.f, 672.f) }

            //rij2
            { Position = Vector2(416.f, 192.f) } 
            { Position = Vector2(416.f, 224.f) }
            { Position = Vector2(416.f, 256.f) }
            { Position = Vector2(416.f, 288.f) }
            { Position = Vector2(416.f, 320.f) }
            { Position = Vector2(416.f, 352.f) }
            { Position = Vector2(416.f, 384.f) }
            { Position = Vector2(416.f, 416.f) }
            { Position = Vector2(416.f, 448.f) }
            { Position = Vector2(416.f, 480.f) }
            { Position = Vector2(416.f, 512.f) }
            { Position = Vector2(416.f, 544.f) }
            { Position = Vector2(416.f, 576.f) }
            { Position = Vector2(416.f, 608.f) }
            { Position = Vector2(416.f, 640.f) }
            { Position = Vector2(416.f, 672.f) }


            //rij3
            { Position = Vector2(608.f, 192.f) } 
            { Position = Vector2(608.f, 224.f) }
            { Position = Vector2(608.f, 256.f) }
            { Position = Vector2(608.f, 288.f) }
            { Position = Vector2(608.f, 320.f) }
            { Position = Vector2(608.f, 352.f) }
            { Position = Vector2(608.f, 384.f) }
            { Position = Vector2(608.f, 416.f) }
            { Position = Vector2(608.f, 448.f) }
            { Position = Vector2(608.f, 480.f) }
            { Position = Vector2(608.f, 512.f) }
            { Position = Vector2(608.f, 544.f) }
            { Position = Vector2(608.f, 576.f) }
            { Position = Vector2(608.f, 608.f) }
            { Position = Vector2(608.f, 640.f) }
            { Position = Vector2(608.f, 672.f) }

            //rij4
            { Position = Vector2(800.f, 192.f) } 
            { Position = Vector2(800.f, 224.f) }
            { Position = Vector2(800.f, 256.f) }
            { Position = Vector2(800.f, 288.f) }
            { Position = Vector2(800.f, 320.f) }
            { Position = Vector2(800.f, 352.f) }
            { Position = Vector2(800.f, 384.f) }
            { Position = Vector2(800.f, 416.f) }
            { Position = Vector2(800.f, 448.f) }
            { Position = Vector2(800.f, 480.f) }
            { Position = Vector2(800.f, 512.f) }
            { Position = Vector2(800.f, 544.f) }
            { Position = Vector2(800.f, 576.f) }
            { Position = Vector2(800.f, 608.f) }
            { Position = Vector2(800.f, 640.f) }
            { Position = Vector2(800.f, 672.f) }
          ] 
}

let getRandomAisle () = 
    let aisleProbability = r.Next(0,3)
    
    let aisle = 
        if aisleProbability = 0 then
            (Vector2(1000.f, 400.f), 0 )
        elif aisleProbability = 1 then
            (Vector2(1200.f, 400.f), 0)
        else 
            (Vector2(2100.f, 400.f) , 0)
            
    aisle

let spawnLocationCustomer() = 
    {
        Customer.Position = Vector2(float32(r.Next(5,35)), float32(r.Next(35, 120)))
        Customer.ShoppingListCount = r.Next(1,4)



        Customer.nextWaypoint = getRandomAisle()
        Customer.CurrentItemLocation = Vector2(606.f, 180.f)
    }


let walk(dt:float32) (customer:Customer): Customer= {
    customer with Position = customer.Position + Vector2.UnitX * dt * 10.0f
}

let walkLogic(dt:float32) (customer:Customer)= 
    if snd customer.nextWaypoint = 0 then
        let waypoint = fst customer.nextWaypoint
        if customer.Position.X < waypoint.X then
           
           customer
        else
            customer
    else
        customer
                                           


let updateCustomers (customers : seq<Customer>) (dt:float32) = 
    //spawn
    let spawnProbability = r.Next(0,1000)
    
    let newCustomers = 
        if spawnProbability > 990 then
            Seq.append customers  [spawnLocationCustomer()]
        else
            customers  
            
    //newCustomers
    
    //TODO: walk to destination
    //call updateCustomer
    //let newCustomers map (updateCustomer dt) newCustomers
    let newCustomers = Seq.map (walkLogic dt) newCustomers
    newCustomers
    //newCustomers
    //TODO: if type = payed --> remove customer


let updateState (gameState : GameState) (dt:float32) = {

    gameState with 
        Customers = updateCustomers gameState.Customers dt
}



//let format:
//name (inputType) : outputType
// name (variable:Type) : returnValue
let drawObstacle (obstacle : Obstacle) : Drawable = 
    { 
    Drawable.Position = obstacle.Position
    Drawable.Image = "obstacle" 
}

let drawcustomer (customer : Customer) : Drawable = 
    {
        Drawable.Image = "customer"
        Drawable.Position = customer.Position
}

let drawState (gameState : GameState) : seq<Drawable> = 
    let listOfCustomers = Seq.map drawcustomer gameState.Customers

    listOfCustomers
    

let drawInitialState (gameState : GameState) : seq<Drawable> = 
    let listOfObstacles = Seq.map drawObstacle gameState.Obstacles 
    
    listOfObstacles

    