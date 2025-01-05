const useEnv = () => {
  return {
    baseUrl: import.meta.env.VITE_REACT_APP_BASE_URL,
    pageSize: import.meta.env.VITE_REACT_APP_PAGE_SIZE,
    firstPage: import.meta.env.VITE_REACT_APP_FIRST_PAGE,
  };
};

export default useEnv;
