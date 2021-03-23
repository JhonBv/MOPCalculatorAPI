class Calculator:
    def __init__(self, operation, number1, number2):
        self.operation = operation
        self.fvalue = number1
        self.svalue = number2

    def doCalculate(self, operation, fvalue, svalue):
            while True:
                if self.operation in ('1','2','3','4'):
                    if self.operation == '1':
                        return fvalue + svalue
                    elif self.operation == '2':
                        return fvalue - svalue
                    elif self.operation == '3':
                        return fvalue * svalue
                    elif self.operation == '4':
                        return fvalue / svalue
                    break
                else:
                    return 0
    def Add(fnumber, snumber):
        return fnumber + snumber;
    def Substruct(sub, fnumber,snuymber):
        return sub.fnumber + sub.snumber;