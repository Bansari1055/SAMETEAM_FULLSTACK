import axios from 'axios';

const API_URL = 'http://localhost:5081/api/auth/';

// Helper to get the stored token
const getToken = () => {
  const user = JSON.parse(localStorage.getItem('user'));
  return user?.token;
};

// Login function
export const login = async (email, password) => {
  try {
    const response = await axios.post(API_URL + 'login', { email, password });
    if (response.data.token) {
      localStorage.setItem('user', JSON.stringify(response.data));
    }
    return response.data;
  } catch (error) {
    console.error("Login error: ", error);
    alert("Login failed");
    throw error;
  }
};

// Register function
export const register = async (firstName, lastName, email, password) => {
  try {
    const response = await axios.post(API_URL + 'register', { firstName, lastName, email, password });
    return response.data;
  } catch (error) {
    console.error("Registration error: ", error);
    alert("Registration failed");
    throw error;
  }
};

// Example protected request with the token
export const fetchProtectedData = async () => {
  try {
    const token = getToken();
    const response = await axios.get('http://localhost:5081/api/protected-endpoint', {
      headers: {
        'Authorization': `Bearer ${token}`,
      },
    });
    return response.data;
  } catch (error) {
    console.error("Error fetching protected data: ", error);
    throw error;
  }
};
