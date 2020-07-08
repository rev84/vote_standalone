window.Fetch = (function() {
  function Fetch() {}
  
  Fetch.request = function(endpoint, params, success, fail) {
    return fetch(endpoint, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(params)
    }).then((response) => {
      console.log(response)
    });
  };
});