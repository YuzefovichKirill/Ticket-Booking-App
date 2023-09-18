import React from "react";

const Datetime = ({datetime: dt}) => {
  
  return (
    <div>
      <div>{new Date(Date.parse(dt)).toLocaleDateString()}</div>
      <div>{new Date(Date.parse(dt)).toLocaleTimeString('en-GB', { hour: "numeric", minute: "numeric"})}</div>
    </div>
  )
}

export default Datetime
