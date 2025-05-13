def calculator():
    print("Welcome to the calculator!")
    while True:
        try:
            numOne = int(input("Enter your first number: "))
            numTwo = int(input("Enter your second number: "))
            operation = input("Enter your operation (+, -, *, or /): ")
            if operation == "+":
                print(f"Result: {numOne + numTwo}")
            elif operation == "-":
                print(f"Result: {numOne - numTwo}")
            elif operation == "*":
                print(f"Result: {numOne * numTwo}")
            elif operation == "/":
                if numTwo != 0:
                    print(f"Result: {numOne / numTwo}")
                else:
                    print("You cannot divide by zero!")
            else:
                print("That is not a valid operation!")
        except ValueError:
            print("That is not a valid number!")

        cont = input("Do you want to do another equation? yes/no: ").lower()

        if cont == "no":
            break
        elif cont != "yes":
            print("That is not a valid answer, please enter yes or no!")

calculator()
