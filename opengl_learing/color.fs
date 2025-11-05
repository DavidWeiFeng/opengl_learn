#version 330 core
out vec4 FragColor;

uniform vec3 objectColor;
uniform vec3 lightColor;
uniform vec3 viewPos;
uniform vec3 lightPos;


in vec3 FragPos;

in vec3 Normal;
void main()
{
    float specularStrength = 0.5;
    vec3 norm = normalize(Normal);
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 lightDir = normalize(lightPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor;
    
    
    float spec= pow(max(dot(viewDir, reflectDir),0.0),32);
    vec3 specular = specularStrength * spec * lightColor;
    vec3 result = (0.2f + diffuse + specular) * objectColor;
    FragColor = vec4(result, 1.0);
;
}