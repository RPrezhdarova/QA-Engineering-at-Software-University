int trainingFee = int.Parse(Console.ReadLine());

double basketballSneakers = trainingFee * 0.6;
double basketballUniform = basketballSneakers * 0.8;
double basketballBall = basketballUniform * 0.25;
double basketballAccessories = basketballBall / 5;

double totalCosts = trainingFee + basketballSneakers + basketballUniform + basketballAccessories + basketballBall;

Console.WriteLine(totalCosts);
