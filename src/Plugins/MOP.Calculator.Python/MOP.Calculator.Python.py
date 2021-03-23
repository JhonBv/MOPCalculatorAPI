class Calculator:
    def __init__(self, operation, number1, number2):
        self.operation = operation
        self.fvalue = number1
        self.svalue = number2

    def doCalculate(self, operation, fvalue, svalue):
            while True:
                if self.operation in ('1','2','3','4'):
                    if self.operation == '1':
                        result = self.fvalue + self.svalue
                        return result
                    elif self.operation == '2':
                        return fvalue - svalue
                    elif self.operation == '3':
                        return fvalue * svalue
                    elif self.operation == '4':
                        return fvalue / svalue
                    break
                else:
                    return 'Invalid operation'

print("Select operation.")
print("1.Add")
print("2.Subtract")
print("3.Multiply")
print("4.Divide")
choice = input("Enter choice(1/2/3/4): ")
if choice in ('1', '2', '3', '4'):
    ch = choice
    num1 = float(input("Enter first number: "))
    num2 = float(input("Enter second number: "))
    result = 0.0
    calc = Calculator(ch, num1, num2)
  
    print(calc.doCalculate(ch,num1,num2))
else:
    print("Invalid Input")
