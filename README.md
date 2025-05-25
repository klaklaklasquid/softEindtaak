# SoftEindtaak WeerEventAPI

**Oneliner:**  
RESTful .NET 9 API voor het beheren van weerstations, metingen en weersvoorspellingen, inclusief logging in JSON en XML.

---

## Build, Run & Test instructies

### Build

dotnet build

### Run

De API start standaard op `http://localhost:5008/` (controleer de console output voor de juiste poort).

### Test
- Open `WeerEventsApi/ApiCalls.http` in Visual Studio.
- Klik op "Send Request" boven een request om de API te testen.
- Of gebruik Postman/curl met de endpoints uit het `.http` bestand.

---

## Known Issues & Notities

- **XML logformaat:**  
  Elke meting wordt als losse `<Meting>...</Meting>` entry toegevoegd aan `log.xml` (geen root element, geen namespaces).
- **JSON logformaat:**  
  Elke meting wordt als losse JSON object (één per regel) toegevoegd aan `log.json`, met enkel de velden `Moment`, `Waarde`, en `Eenheid`.
- **Weerbericht endpoint:**  
  Eerste call duurt ~5 seconden door gesimuleerde zware berekening; volgende calls binnen 1 minuut zijn direct (caching proxy).
- **Geen database:**  
  Alle data wordt in-memory bijgehouden; bij herstart zijn metingen weg.
- **Stedenbestand:**  
  Zorg dat het JSON-bestand met steden (`Steden/Data/steden.json`) aanwezig is, anders start de applicatie niet correct.

**Oplossingen:**  
- Voor XML/JSON logging: custom formatters worden gebruikt om aan de opdrachtvereisten te voldoen.
- Voor performance: caching proxy voor het weerbericht voorkomt onnodige vertraging bij herhaalde requests.

---

## ( informal ) ClassDiagram

![classdiagram](image/UML.png)
