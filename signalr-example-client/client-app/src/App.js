import "./App.css";
import React, { useEffect, useState } from "react";
import SignalRHubService from "./Services/SignalRHubService";

function App() {
  const [changes, setChanges] = useState([]);

  const signalRHubService = new SignalRHubService()

  useEffect(() => {
    signalRHubService.startConnection("http://localhost:5078/database-hub");
    signalRHubService.addTableChangeListner("PersonTableChanged", (personChangeModel) => {
      setChanges((prevChanges) => [...prevChanges, personChangeModel]);
    });
  }, []);

  return (
    <div className="App">
      <h1>Simple SignalR Client</h1>

      <div>
        <ul>
          {changes.map((change, index) => {
            return (
              <li key={index}>
                <b>Id:</b> {change.personId} <b>Name & Surname:</b> {change.name} {change.surname} <b>Change Reason:</b> {change.changeReason}
              </li>
            );
          })}
        </ul>
      </div>
    </div>
  );
}

export default App;
