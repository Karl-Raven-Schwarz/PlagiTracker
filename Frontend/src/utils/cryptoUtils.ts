// src/utils/cryptoUtils.ts
import CryptoJS from 'crypto-js';

// Accede a las variables de entorno
const plagiTrackerSecretKey = CryptoJS.enc.Utf8.parse(import.meta.env.VITE_ENCRYPT_KEY || ''); // 16 bytes para AES-128
const plagiTrackerIV = CryptoJS.enc.Utf8.parse(import.meta.env.VITE_IV || ''); // 16 bytes

// Función para cifrar texto
export const encrypt = (text: string): any => {
  console.log('Encrypting:', text);
  return hashPassword(text); // Devuelve como una cadena
};

function hashPassword(password: string) {
    const sha256Hash = CryptoJS.SHA256(password);
    return CryptoJS.enc.Base64.stringify(sha256Hash);
}

// Función para descifrar texto
export const decrypt = (ciphertext: string): string => {
  try {
    console.log('Decrypting:', ciphertext);
    const bytes = CryptoJS.AES.decrypt(ciphertext, plagiTrackerSecretKey, { iv: plagiTrackerIV });
    const decrypted = bytes.toString(CryptoJS.enc.Utf8);

    // Verificar si el texto descifrado está vacío
    if (decrypted === '' && bytes.toString() !== '') {
      throw new Error('Decryption failed');
    }

    return decrypted;
  } catch (error) {
    console.error('Decryption error:', error);
    throw error;
  }
};