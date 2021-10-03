import axios from 'axios';
const apiClient = axios.create({
    baseURL: 'https://104.215.186.78/',
    withCredentials: false,
    headers: {
        // 'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    },
    
})

export default {
    getToken(tokenId){
        return apiClient.post('api/authentications/login/'+ tokenId) 
    }
}