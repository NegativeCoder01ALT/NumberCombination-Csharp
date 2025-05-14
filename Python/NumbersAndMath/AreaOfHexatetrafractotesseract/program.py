# imports
import math

# code
while True:
    try: 
        edgeLength = int(input("Enter the edge length: "))
        eqOne = math.pow(edgeLength, 4)
        eqTwo = 14*math.pow(edgeLength, 3)
        area = eqOne+eqTwo/math.sqrt(2)
        print (f"The area of the hexate is: {area} cm⁴")
        break
    except ValueError:
        print ("That is not a valid number!")