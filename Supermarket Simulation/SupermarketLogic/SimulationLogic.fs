﻿module SimulationLogic

open Microsoft.Xna.Framework

let r = new System.Random()
let mutable idCount = 0;

type ShoppingItem = {
    Position : Vector2
    Value : int
}

type ShoppingItems = {
    Items : list<ShoppingItem>
}

let initShoppingItems = {
    Items =
        [
            {Position = Vector2(261.f,439.f); Value = 3}
            {Position = Vector2(448.f,569.f); Value = 4}
            {Position = Vector2(664.f,511.f); Value = 10}
            {Position = Vector2(218.f,498.f); Value = 16}
            {Position = Vector2(408.f,553.f); Value = 8}
            {Position = Vector2(599.f,557.f); Value = 19}
            {Position = Vector2(795.f,526.f); Value = 6}
            {Position = Vector2(834.f,467.f); Value = 2}
        ]
}

type Register = {
    Position : Vector2
}

type Registers = {
    Registers : list<Register>
}

let initRegisters = {
    Registers = 
        [
              {Position = Vector2(551.f,864.f);}
              {Position = Vector2(210.f,864.f);}
              {Position = Vector2(906.f,864.f);}
        ]
}

let getRandomShoppingItem (list : List<ShoppingItem>) : ShoppingItem =
     let item = list.[r.Next(0,8)]
     item


type Drawable = 
    { Position : Vector2
      Image : string }

type Obstacle = 
    { Position : Vector2 }

type CustomerPathFinding = 
    |GoToAisleX
    |GoToAisleY
    |GoBack
    |GoToRegisterX
    |GoToRegisterY
    |Checkout

type TotalCash = 
    {
        Cash : int
        Position : Vector2
    }
type Customer = 
    {
        Id : int
        Position: Vector2
        ShoppingListCount : int
        BasketValue : int
        CurrentShoppingTarget : ShoppingItem
        CurrentRegisterTarget : Register
        Status: CustomerPathFinding
    }



type GameState = 
    {   
        Obstacles : seq<Obstacle>
        Customers : seq<Customer>
        TotalCash : TotalCash
    }

let initialState() = 
    { 
        TotalCash = 
                {Cash = 0; Position = Vector2(800.f, 54.f)}

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

let spawnLocationCustomer() = 
    {
        Customer.Id = r.Next(0, 999999)
        Customer.Position = Vector2(float32(r.Next(5,35)), float32(r.Next(35, 120)))
        Customer.ShoppingListCount = r.Next(1,4)
        Customer.BasketValue = 0
        Customer.Status = GoToAisleX
        Customer.CurrentShoppingTarget = initShoppingItems.Items.Item(r.Next(0,initShoppingItems.Items.Length))
        Customer.CurrentRegisterTarget =  initRegisters.Registers.Item(r.Next(0, initRegisters.Registers.Length))
    }
    
let updateCustomer (shoppingItem: ShoppingItem) (dt:float32) (customer:Customer) : Customer = 

    //customer with Position = customer.Position + Vector2.UnitX * dt * 100.0f
    let customer =
    //moving customer.position.X to align with shoppingtarget.X
        match customer.Status with
        | GoToAisleX -> 
            if customer.Position.X + 10.f < customer.CurrentShoppingTarget.Position.X  then // target is right
                {customer with Position = customer.Position + Vector2.UnitX * dt * 75.0f}
            elif customer.Position.X - 10.f > customer.CurrentShoppingTarget.Position.X then //target is left
                {customer with Position = customer.Position - Vector2.UnitX * dt * 75.0f}
            else
                {customer with Status = GoToAisleY}

        | GoToAisleY ->
            if customer.Position.Y < customer.CurrentShoppingTarget.Position.Y then
                {customer with Position = customer.Position + Vector2.UnitY * dt * 75.0f}
            else
            //grabbing item + get new shoppingitem target
                {customer with Status = GoBack;  ShoppingListCount = customer.ShoppingListCount - 1; CurrentShoppingTarget = shoppingItem; BasketValue = customer.BasketValue + shoppingItem.Value }
        | GoBack ->
            if customer.Position.Y > 107.f then
                 {customer with Position = customer.Position - Vector2.UnitY * dt * 75.0f}
            else
                if customer.ShoppingListCount = 0 then //has still some shopping to do?
                        {customer with Status = GoToRegisterY}   
                else //no more shopping to do?
                    {customer with Status = GoToAisleX}
        | GoToRegisterY ->
            if customer.Position.Y < 864.f then
                  {customer with Position = customer.Position + Vector2.UnitY * dt * 75.0f}
            else 
                {customer with Status = GoToRegisterX}
        | GoToRegisterX ->
            if customer.Position.X < customer.CurrentRegisterTarget.Position.X then
                {customer with Position = customer.Position + Vector2.UnitX * dt * 75.0f}
            elif  customer.Position.X > customer.CurrentRegisterTarget.Position.X then
                {customer with Position = customer.Position - Vector2.UnitX * dt * 75.0f}
            else
                  {customer with Status = Checkout}

        | Checkout -> customer

        | _ -> customer    
    customer

//    let updateTotalCash  (customer:Customer) (totalCash:TotalCash) : TotalCash  = 
//        //TODO
//        match
//        //check if status = checkout
//        // if true -> add basketvalue to totalCash
//        // remove customer
//        {totalCash with Cash = totalCash.Cash + customer.BasketValue}
        
    //TODO check which way based on the customer status
    //TODO if reached destination --> change status


let updateCustomers (customers : seq<Customer>) (dt:float32)   = 
    //spawn
    let spawnProbability =
        if Seq.length customers < 10 then
            r.Next(0,1000)
        else
            0
    
    let newCustomers = 
        if spawnProbability > 990 then
            Seq.append customers  [spawnLocationCustomer()]
        else
            customers  
            
    //TODO: walk to destination
    //call updateCustomer
    let newCustomers = Seq.map (updateCustomer (getRandomShoppingItem initShoppingItems.Items) dt)  newCustomers      
    newCustomers

    //TODO: if type = payed --> remove customer


let updateState (gameState : GameState) (dt:float32) = {

    gameState with Customers = updateCustomers gameState.Customers dt; 
                    //TotalCash = Seq.map upd   
   // gameState with TotalCash = //iterate over customers with status checkout
}



//let format:
//name (inputType) : outputType
// name (variable:Type) : returnValue
let drawObstacle (obstacle : Obstacle) : Drawable = 
    { 
    Drawable.Position = obstacle.Position
    Drawable.Image = "obstacle" 
}

let drawTotalCash (totalcash : TotalCash) : TotalCash = 
    {
        TotalCash.Cash = totalcash.Cash
        TotalCash.Position = totalcash.Position
    }

let drawcustomer (customer : Customer) : Drawable = 
    {
        Drawable.Image = "customer"
        Drawable.Position = customer.Position
}

let drawState (gameState : GameState) : seq<Drawable> = 
    let listOfCustomers = Seq.map drawcustomer gameState.Customers

    listOfCustomers

let drawCashState (gameState : GameState) : TotalCash = 
    let totalCash = drawTotalCash gameState.TotalCash

    totalCash

let drawInitialState (gameState : GameState) : seq<Drawable> = 
    let listOfObstacles = Seq.map drawObstacle gameState.Obstacles 
    
    listOfObstacles

    