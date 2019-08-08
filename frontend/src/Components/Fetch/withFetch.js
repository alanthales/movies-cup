import React, { useState, useEffect } from "react";
import http from "../../Helpers/http";

const useFetch = (url, initialData, method = "get", body = null) => {
  const [data, setData] = useState(initialData),
    [isLoading, setIsLoading] = useState(true),
    [hasError, setHasError] = useState(false);
  
  useEffect(() => {
    async function fetchData() {
      let result = await http[method](url, body)
        .then(data => data)
        .catch(() => {
          setHasError(true);
          return null;
        });

      setData(result);
      setIsLoading(false);
    }
    fetchData();
  }, [url, method, body]);

  return [data, isLoading, hasError];
};

const withFetch = ({ url, initialData = [], method = "get", body = null }) => (WrappedComponent) => {
  return (props) => {
    const [data, isLoading, hasError] = useFetch(url, initialData, method, body);
    return (
      <WrappedComponent
        {...props} 
        data={data} 
        isLoading={isLoading}
        hasError={hasError} />
    );
  };
};

export { useFetch };

export default withFetch;