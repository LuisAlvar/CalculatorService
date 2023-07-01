
netsh http add urlacl url=http://+:8081/ user=desktop-644g20u\alvar
resutl --> URL reservation successfully added

netsh http add urlacl url=http://+:8080/CalculatorServiceSvc/ user=desktop-644g20u\alvar
resutl -->  URL reservation successfully added

netsh http show urlacl url=http://+:8080/CalculatorServiceSvc/

netsh http delete urlacl url=http://+:8080/CalculatorServiceSvc/

netsh http add urlacl url=http://+:8765/CalculatorServiceSvc/ user=desktop-644g20u\alvar


netsh http add urlacl url=http://+:8765/CalculatorServiceSvc.svc user=desktop-644g20u\alvar

