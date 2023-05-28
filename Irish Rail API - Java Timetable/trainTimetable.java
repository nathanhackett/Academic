//CS402 Assignment option 7
//18321563

import java.io.*;
import org.w3c.dom.*;
import javax.xml.parsers.*;
import java.net.URL;

public class trainTimetable {
    public static void main(String args[]) throws IOException, org.xml.sax.SAXException, ParserConfigurationException {
        // create new HTML file to hold the table
        File timetable = new File("Dublin Heuston Timetable.html");
        // IrishRail API URL
        URL API = new URL(
                "http://api.irishrail.ie/realtime/realtime.asmx/getStationDataByCodeXML_WithNumMins?StationCode=CNLLY&NumMins=90&format=xml");

        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        // DBF Defines a factory API that enables applications to obtain a parser that
        // produces DOM object trees from XML documents
        DocumentBuilder db = dbf.newDocumentBuilder();
        Document doc = db.parse(API.openStream()); // parse XML document to document
        NodeList trainData = doc.getElementsByTagName("objStationData");
        // fetch XML array, converts each station to a node

        BufferedWriter bw = new BufferedWriter(new FileWriter(timetable, true));
        BufferedReader br = new BufferedReader(new FileReader(timetable));
        StringBuilder sb = new StringBuilder();
        String data = sb.toString();
        String string;
        while ((string = br.readLine()) != null)
            sb.append(string);
        br.close();

        // build HTML file with single string
        // import Bootstrap 5 styling
        String HTML = "<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3\" crossorigin=\"anonymous\">\r\n"
                + "<style>\r\n"
                + "table {\r\n"
                + "  width: 90%;\r\n"
                + "  margin-left: auto;\r\n"
                + "  margin-right: auto;\r\n"
                + "}\r\n"
                + "\r\n"
                + "th {\r\n"
                + "  background-color: #dddddd;\r\n"
                + "  border: 1px solid #aaaaaa;\r\n"
                + "  padding: 8px;\r\n"
                + "}\r\n"
                + "\r\n"
                + "td {\r\n"
                + "  border: 1px solid #aaaaaa;\r\n"
                + "  padding: 8px;\r\n"
                + "}\r\n"
                + "\r\n"
                + "h1 {\r\n"
                + "  font-family: arial, sans-serif;\r\n"
                + "  text-align: center;\r\n"
                + "}\r\n"
                + "\r\n"
                + "img {\r\n"
                + "  width: 500px;\r\n"
                + "  display: block;\r\n"
                + "  margin-left: auto;\r\n"
                + "  margin-right: auto;\r\n"
                + "}\r\n"
                + "</style>\r\n"
                + "<img\r\n"
                + "src=\"https://upload.wikimedia.org/wikipedia/commons/thumb/c/cc/Irish_Rail_Logo.svg/1920px-Irish_Rail_Logo.svg.png?20200512192419\"\r\n"
                + "/>\r\n"
                + "<br/>"
                + "<h1>Station: <b>\r\n"
                + ((Element) trainData.item(0)).getElementsByTagName("Stationfullname").item(0).getTextContent()
                + "\r\n"
                + "</b></h1>\r\n"
                + "<table>\r\n<tr><th>Train Code:</th><th>Origin:</th><th>Destination:</th><th>Scheduled Departure:</th><th>Expected Departure:</th><th>Scheduled Arrival:</th><th>Expected Arrival:</th></tr>\r\n";

        // loop through train stations array
        for (int i = 0; i < trainData.getLength(); i++) {
            Node trainNode = trainData.item(i);
            // cast train nodes to element for use in the string builder
            Element train = (Element) trainNode;
            // create new row with corresponding heading for each train
            String stationTimetable = "<tr><td>"
                    + train.getElementsByTagName("Traincode").item(0).getTextContent()
                    + "</td><td>"
                    + train.getElementsByTagName("Origin").item(0).getTextContent()
                    + "</td><td>"
                    + train.getElementsByTagName("Destination").item(0).getTextContent()
                    + "</td><td>"
                    + train.getElementsByTagName("Schdepart").item(0).getTextContent()
                    + "</td><td>"
                    + train.getElementsByTagName("Expdepart").item(0).getTextContent()
                    + "</td><td>"
                    + train.getElementsByTagName("Scharrival").item(0).getTextContent()
                    + "</td><td>"
                    + train.getElementsByTagName("Exparrival").item(0).getTextContent()
                    + "</td></tr>\r\n";
            HTML += stationTimetable;
        }
        HTML += "</table>";
        HTML += "<br/>";

        PrintWriter writer = new PrintWriter(timetable);
        writer.print("");
        writer.close();
        data = HTML;
        // call buffered writer to write HTML string to the file declared on line 12
        bw.write(data);
        bw.close();
    }
}