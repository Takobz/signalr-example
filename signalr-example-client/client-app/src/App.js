import "./App.css";
import React, { useEffect, useState } from "react";
import SignalRHubService from "./Services/SignalRHubService";

function App() {
  const [changes, setChanges] = useState([
    { TableName: "Initial Load", ItemId: 1 },
  ]);

  const signalRHubService = new SignalRHubService()

  useEffect(() => {
    signalRHubService.startConnection("http://localhost:5078/database-hub");
    signalRHubService.addTableChangeListner("PersonTableChanged", (tableChangeModel) => {
      setChanges((prevChanges) => [...prevChanges, tableChangeModel]);
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
                Table: {change.TableName} Identifier: {change.ItemId}
              </li>
            );
          })}
        </ul>
      </div>
    </div>
  );
}

export default App;
