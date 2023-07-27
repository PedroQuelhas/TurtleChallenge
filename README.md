
# TurtleChallenge

  

This project was made as part of the recruitment process for LetsGetChecked

  

The objective is to lead a turtle through a board and evaluate the board's conditions

  

The code is "over-engineered", and I would not start with something as complex as this from the get-go... However, this is also a show of skills.

I also noticed I forgot to have the initial direction of the turtle taken into consideration... Minor detail.

  

The project contains a few Unit tests for demonstration purposes (clearly not enough for production-grade projects).

  

I also added a little extra detail (which was a super time suck, but fun anyways), where you can see the board being rendered and the turtle moving...

It ended up a little half-baked because the lib I used (spectre console) sucks from drawing canvas.


## Input format

Settings file:
```json
{
   "rows":5,
   "columns":4,
   "startPoint":{
      "x":0,
      "y":3
   },
   "exit":{
      "x":3,
      "y":0
   },
   "mines":[
      {
         "x":2,
         "y":2
      },
      {
         "x":1,
         "y":3
      },
      {
         "x":3,
         "y":1
      }
   ]
}
```
    Moves file:
```json
{
   "sequences":[
      [
         "M",
         "R",
         "M",
         "R",
         "R",
         "R",
         "M",
         "M"
      ],
      [
         "M",
         "R",
         "M",
         "R",
         "R",
         "R",
         "M",
         "M",
         "R",
         "M",
         "M"
      ],
      [
         "M",
         "R",
         "M",
         "R",
         "R",
         "R",
         "M",
         "M",
         "M",
         "M",
         "M",
         "M",
         "M"
      ],
      [
         "R",
         "M",
         "M"
      ]
   ]
}
```

  
  

## Usage

  

dotnet run .\TurtleChallenge.csproj SettingsExample.json MovesExample.json <true/false> (visualization)


## References
[Spectre Console](https://spectreconsole.net/)
[FakeItEasy](https://fakeiteasy.github.io/docs/7.4.0/)
[FluentAssertions](https://fluentassertions.com/)