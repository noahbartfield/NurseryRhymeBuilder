import React, { useState, useEffect } from 'react';
import { createAuthHeaders } from '../API/userManager';

function Home() {
  const [values, setValues] = useState([]);

  useEffect(() => {
    const authHeader = createAuthHeaders();
    console.log("authHeader: ", authHeader)
    fetch('/api/v1/Values', {
      headers: authHeader
    })
      .then(response => response.json())
      .then(setValues);
  }, []);

  
    return (
      <>
        <h1>Welcome to my app</h1>
        <ul>
          {
            values.map((value, index) => <li key={index}>{value}</li>)
          }
        </ul>
      </>
    )
}

export default Home;