## Allgemein

Get your game on ist ein Browserspiel, das in Godot mit C# erstellt wurde. Als solches benötigt das Spiel mindestens WebGL 1.0, um zu laufen. WebGL 1.0 wird von allen modernen Browsern unterstützt, die nach 2012 veröffentlicht wurden [1]. Das Spiel ist für das Spielen mit Maus und Tastatur konzipiert. Touchscreen-Eingaben werden nicht unterstützt.

Während der Entwicklung wurde das Spiel hauptsächlich auf den folgenden Browsern getestet

Chrome 120, sowie andere Chromium-basierte Browser wie Edge oder Opera.
Firefox 121.0
Safari unter MacOS 17.2
Die Tests wurden sowohl auf High-End- als auch auf Low-End-Hardware durchgeführt. Get Your Game On hat sehr geringe Systemanforderungen und sollte auf den meisten Geräten spielbar sein.

## Architektur
Um die Aufgaben sicher und fair zu halten, ist das Spiel in zwei Teile unterteilt: den Client und den Server. Der Client ist das Spiel selbst, das im Browser läuft.

Zunächst wird der Bewerber vom Server authentifiziert und erhält eine UUID. Anschließend erhält der Client ein Token, das er für den Rest der Sitzung verwendet. Mit diesem Token authentifiziert sich der Client dann bei jeder Anfrage gegenüber dem Server. Der Server ist für die Speicherung der Spielergebnisse zuständig. Wenn das Spiel in Zukunft um zufällige Aufgaben erweitert wird, ist der Server auch für die Entscheidung über die Aufgaben zuständig.

### Server
Der Server übernimmt die Authentifizierung des Bewerbers und speichert die Ergebnisse. Sollte der Server ebenfalls von Spore Games entwickelt werden, so würde er in Java geschrieben werden. Der Server würde auf einem von der HNU bereitgestellten Server gehostet werden. Er ist für die folgenden Aufgaben zuständig:

- Authentifizierung des Bewerbers
- Speichern der Aufgabe
- Anzeigen der Ergebnisse aller Bewerber in einer Rangliste

Für diese Aufgaben wird eine Datenbank benötigt. Es würde eine SQL-Datenbank verwendet werden. Die Datenbank könnte auf demselben physischen Server wie der Server selbst gehostet werden, da nur eine geringe Anzahl von Anfragen zu erwarten ist.

Das Datenbankschema würde wie folgt aussehen

- Eine Tabelle zur Speicherung der UUID und der HISinOne-ID des Bewerbers. Die HISinOne-ID würde für die Authentifizierung verwendet und die UUID würde zur Identifizierung des Bewerbers in der Datenbank dienen. Die UUID wird vom Server generiert und ist für jeden Bewerber eindeutig. Die HISinOne-ID wird zur Authentifizierung des Bewerbers verwendet.
- Eine Tabelle zur Speicherung der Ergebnisse. Die Tabelle würde die UUID des Bewerbers, die Beurteilungs-ID und das Ergebnis der Beurteilung enthalten. Das Ergebnis wird als JSON-Objekt gespeichert, das die Punktzahl und alle für die Bewertung erforderlichen Zusatzinformationen enthält. Die Managementaufgabe würde z. B. die für die Aufgabe benötigte Zeit und die vom Bewerber ausgewählten Karten enthalten.
- Eine Tabelle zur Speicherung der hochgeladenen Dateien für die Art-Aufgabe. Die Tabelle würde sowohl die UUID des Bewerbers als auch die Datei selbst enthalten. Die Datei wird als binäres Objekt oder als Verweis auf eine Datei auf dem Server gespeichert.

### Authentifizierung
Der Authentifizierungsprozess hängt davon ab, wie die HNU das Assessment nutzen möchte. Wenn das Assessment als Teil des Zulassungsverfahrens verwendet werden soll, muss die Authentifizierung über eine Schnittstelle mit dem HISInOne-Portal erfolgen. Nach öffentlich zugänglichen Informationen [2] verfügt HISInOne über eine SOAP-Schnittstelle für seine Daten. Möglicherweise ist auch eine modernere REST-API verfügbar, die jedoch nicht öffentlich dokumentiert ist. Der Authentifizierungsprozess würde dann wie folgt ablaufen:

1. Der Bewerber meldet sich wie gewohnt im HISinOne-Portal an und klickt auf den Link zum Spiel.
2. Das HISinOne-Portal leitet den Bewerber mit einem Token zurück zum Spiel.
3. Das Spiel sendet den Token an den Server, der sich dann mit dem Token bei HISinOne authentifiziert.
4. Der Server erhält das Authentifizierungsergebnis von HISinOne und sendet es an den Bewerber zurück.
5. Ist die Authentifizierung erfolgreich, erhält der Client ein Sitzungs-Token, das er für den Rest der Sitzung verwenden kann.
   2. Die Authentifizierung kann fehlschlagen, wenn der Benutzer kein Kandidat ist oder wenn der Kandidat das Assessment bereits abgeschlossen hat.
   3. Der Server speichert nur einen Verweis auf die HISinOne-ID des Bewerbers, z. B. eine UUID, die bei der Anmeldung generiert wird, und speichert außer den Ergebnissen keine weiteren persönlichen Informationen.
5. Der Client verwendet das Sitzungs-Token, um sich bei jeder weiteren Anfrage gegenüber dem Server zu authentifizieren.
   
HNU-Mitarbeiter können auf ähnliche Weise authentifiziert werden, allerdings unter Verwendung des bereits vorhandenen Schibboleth SSO-Authentifizierungssystems.

### Client-Server-Kommunikation
Die Kommunikation zwischen Server und Client erfolgt über HTTPS-Anfragen. Die meisten Anfragen werden als JSON-Objekte gesendet. Der Server akzeptiert nur Anfragen, die mit einem Sitzungs-Token authentifiziert sind. Der Server antwortet mit einem JSON-Objekt, das das Ergebnis der Anfrage enthält.

Die folgenden Informationen werden an den Server gesendet
- Informationen, die der Bewerber während des Spiels eingegeben hat, z. B. seine Spezialisierung.
- Das Ergebnis einer der Aufgaben, nachdem der Bewerber sie abgeschlossen hat.
- Das Ergebnis des gesamten Spiels, nachdem der Bewerber es beendet hat.
- Optional, die hochgeladene Datei für die Art-Aufgabe. Siehe Anmerkung unten.
  
Die folgenden Daten werden vom Server empfangen:
- Das Ergebnis des Authentifizierungsprozesses.
- Bereits abgeschlossene Spielstände, wenn das Spiel gestartet und dann vor dem Abschluss geschlossen wurde.

Das Ergebnis des Authentifizierungsprozesses.
Bereits abgeschlossene Spielstände, wenn das Spiel gestartet und dann vor der Fertigstellung geschlossen wurde.
Ein Beispiel für das JSON für die Managementaufgabe, die an den Server gesendet wird:
```json
{
   "token": "<session token>",
   "assessment": "management-1",
   "result": [
      {
         "points": 32,
         "time": 321,
         "cards": [
            {
               "id": 20,
               "slot": 1
            },
            {
               "id": 22,
               "slot": 3
            }
         ]
      }
   ]
}
```
Der Server antwortet mit einem JSON-Objekt, das das Ergebnis der Anfrage enthält. In diesem Fall ist es ziemlich einfach:
```json
{
   "success": true
}
```
Im Falle eines Fehlers antwortet der Server mit einem JSON-Objekt, das die Fehlermeldung enthält:
```json
{
   "success": false,
   "error": "Invalid token"
}
```

### Hinweis: Art-Aufgabe
Wenn die Art-Aufgabe digital eingereicht werden soll, kann der Bewerber die Datei auf den Server hochladen. Der Server speichert dann die Datei und die Datei steht der HNU zur Überprüfung zur Verfügung.
Für die Speicherung der Datei kann entweder eine PostgreSQL- oder Microsoft SQL-Datenbank oder ein Dateiserver verwendet werden. Die Datenbank wäre die einfachere Lösung, da keine zusätzliche Software auf dem Server installiert werden müsste. Ein Dateiserver wäre jedoch effizienter, da die Datei nicht in ein Binärformat konvertiert werden müsste. Die PostgreSQL- und Microsoft SQL-Datenbanken haben außerdem eine Dateigrößenbeschränkung von 1 GB bzw. 2 GB, was für die Art-Aufgabe zu klein sein könnte.

## Generierung von Ranglisten
Der Server ist für die Erstellung der Ranglisten verantwortlich. Die Ranglisten werden den HNU-Mitarbeitern über eine Weboberfläche unter Verwendung ihres HNU-Kontos angezeigt. Wenn der Server von Spore Games entwickelt wird, wird das Webinterface der Einfachheit halber in das Spiel integriert.

Die Ergebnisse werden nach Prozentsatz gewertet. Der Prozentsatz wird berechnet, indem die Anzahl der Bewerber, die weniger Punkte als der Bewerber erzielt haben, durch die Gesamtzahl der Bewerber geteilt wird. Das Perzentil wird dann mit 100 multipliziert, um einen Prozentsatz zu erhalten. Wenn ein Kandidat beispielsweise im 80. Perzentil liegt, bedeutet dies, dass 80 % aller Bewerber schlechter als der Kandidat abgeschnitten haben.

Ranglisten können sowohl für einzelne Beurteilungen als auch für das gesamte Spiel erstellt werden.
Die Ranglisten können auch nach Spezialisierung gefiltert werden. Dabei werden nur die Bewerber in die Rangliste aufgenommen, die die angegebene Spezialisierung gewählt haben. Wenn keine Spezialisierung ausgewählt wurde, werden alle Bewerber in die Rangliste aufgenommen.

Es ist auch möglich, die Ergebnisse der einzelnen Bewerber einzusehen. So kann man zum Beispiel sehen, welche Beurteilungen der Bewerber absolviert hat und wie er bei den einzelnen Beurteilungen abgeschnitten hat, einschließlich individueller Ergebnisse wie die Zeit, die er für die Beurteilung benötigt hat, oder spezifische Lösungen, die der Bewerber geliefert hat.

## Sources

[1] https://caniuse.com/?search=webgl

[2] https://www.campussource.de/events/e1603dortmund/docs/Wassmann_HISinOne.pdf
